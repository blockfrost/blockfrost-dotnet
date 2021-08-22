#!/bin/bash
#
# Script to create the test vector
SCRIPT=$(readlink -f "$0")
VDIR=$(dirname $SCRIPT)
DDIR=$(dirname $VDIR)
AMOUNT=5000
MAGIC=1097911063

echo "Creating Test Vector 01..."

##
## calculate fees for reference tx
##
utxo_table=$(cardano-cli query utxo \
--testnet-magic $MAGIC \
--address $(cat $DDIR/keys/payment1.addr)
)
utxo_table_cells=($(echo $utxo_table | tr " " "\n"))
_txIn=${utxo_table_cells[-4]}

##
## create draft transaction from wallet A to wallet B
##
cardano-cli transaction build-raw \
            --tx-in $_txIn#0 \
            --tx-out $(cat $DDIR/keys/payment1.addr)+0 \
            --tx-out $(cat $DDIR/keys/payment2.addr)+0 \
            --fee 0 \
            --out-file $VDIR/reference.draft

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
_change=$((_total-(_out+_fee)))
_out=$AMOUNT

if [ $_total -lt $AMOUNT ]; then
  echo "failed! (insufficent funds: you have $_total lovelace, you spend $AMOUNT lovelace)"
  exit -1
fi

## 
## build transaction with actual fee
##
cardano-cli transaction build-raw \
            --tx-in $_txIn#0 \
            --tx-out $(cat $DDIR/keys/payment1.addr)+$_change \
            --tx-out $(cat $DDIR/keys/payment2.addr)+$_out \
            --fee $_fee \
            --out-file $VDIR/tx.draft

cardano-cli transaction sign \
            --tx-body-file $VDIR/tx.draft \
            --signing-key-file $DDIR/keys/payment1.skey \
            --testnet-magic $MAGIC \
            --out-file $VDIR/tx.signed

xxd -r -p <<< $(jq .cborHex $VDIR/tx.signed) > $VDIR/tx.raw

echo "done."
exit 0