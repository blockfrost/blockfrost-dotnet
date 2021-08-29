#!/bin/bash
#
# Script to create the test vector
SCRIPT=$(readlink -f "$0")
VDIR=$(dirname $SCRIPT)
DDIR=$(dirname $VDIR)

VID=$(jq .id $VDIR/vector.json)
VDESC=$(jq .description $VDIR/vector.json)
SENDR=$(jq .sender $VDIR/vector.json)
RECVR=$(jq .receiver $VDIR/vector.json)
AMOUNT=$(jq .amount $VDIR/vector.json)
MAGIC=$(jq .magic $VDIR/vector.json)

_minUtxo=$(jq .minUTxOValue $DDIR/protocol.json)

if [ $_minUtxo -gt $AMOUNT ]; then
  echo "failed! (utxo amount: minUTxOValue $_minUtxo lovelace, you spend $AMOUNT lovelace)"
  exit -1
fi

echo "Creating Test Vector $VID..."
echo $VDESC

##
## calculate fees for reference tx
##
utxo_table=$(cardano-cli query utxo \
--testnet-magic $MAGIC \
--address $(cat $DDIR/keys/$SENDR.addr)
)
utxo_table_cells=($(echo $utxo_table | tr " " "\n"))
_txIn=${utxo_table_cells[-4]}

##
## create draft transaction from wallet A to wallet B
##
cardano-cli transaction build-raw \
            --tx-in $_txIn#0 \
            --tx-out $(cat $DDIR/keys/$SENDR.addr)+0 \
            --tx-out $(cat $DDIR/keys/$RECVR.addr)+0 \
            --fee 0 \
            --out-file $VDIR/reference.draft

xxd -r -p <<< $(jq .cborHex $VDIR/reference.draft) > $VDIR/reference.draft.raw

cardano-cli transaction sign \
            --tx-body-file $VDIR/reference.draft \
            --signing-key-file $DDIR/keys/$SENDR.skey \
            --testnet-magic $MAGIC \
            --out-file $VDIR/reference.signed

xxd -r -p <<< $(jq .cborHex $VDIR/reference.signed) > $VDIR/reference.signed.raw

min_fee=$(cardano-cli transaction calculate-min-fee \
--tx-body-file $VDIR/reference.draft \
--tx-in-count 1 \
--tx-out-count 2 \
--witness-count 1 \
--testnet-magic $MAGIC \
--protocol-params-file $DDIR/protocol.json
)
min_fee_cells=($(echo $min_fee | tr " " "\n"))
_total=${utxo_table_cells[-2]}
_fee=${min_fee_cells[-2]}
_out=$AMOUNT
_change=$((_total-(_out+_fee)))

if [ $_total -lt $AMOUNT ]; then
  echo "failed! (insufficent funds: you have $_total lovelace, you spend $AMOUNT lovelace)"
  exit -1
fi

## 
## build transaction with actual fee
##
cardano-cli transaction build-raw \
            --tx-in $_txIn#0 \
            --tx-out $(cat $DDIR/keys/$SENDR.addr)+$_change \
            --tx-out $(cat $DDIR/keys/$RECVR.addr)+$_out \
            --fee $_fee \
            --out-file $VDIR/tx.draft

xxd -r -p <<< $(jq .cborHex $VDIR/tx.draft) > $VDIR/tx.draft.raw

cardano-cli transaction sign \
            --tx-body-file $VDIR/tx.draft \
            --signing-key-file $DDIR/keys/$SENDR.skey \
            --testnet-magic $MAGIC \
            --out-file $VDIR/tx.signed

xxd -r -p <<< $(jq .cborHex $VDIR/tx.signed) > $VDIR/tx.signed.raw

echo "tot:$_total"
echo "out:$_out"
echo "fee:$_fee"
echo "chg:$_change"
echo "chg+fee:$(($_change+$_fee))"

echo "done."
exit 0
