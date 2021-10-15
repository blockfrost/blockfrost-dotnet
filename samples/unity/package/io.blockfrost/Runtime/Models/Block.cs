namespace Blockfrost.Models
{
    /// <summary>Block</summary>
    [System.Serializable]
    public class Block
    {
        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        /// <returns>
        /// Block creation time in UNIX time
        /// </returns>
        public long time { get; set; }

        /// <summary>
        /// Gets or sets the Height
        /// </summary>
        /// <returns>
        /// Block number
        /// </returns>
        public long height { get; set; }

        /// <summary>
        /// Gets or sets the Hash
        /// </summary>
        /// <returns>
        /// Hash of the block
        /// </returns>
        public string hash { get; set; }

        /// <summary>
        /// Gets or sets the Slot
        /// </summary>
        /// <returns>
        /// Slot number
        /// </returns>
        public long slot { get; set; }

        /// <summary>
        /// Gets or sets the Epoch
        /// </summary>
        /// <returns>
        /// Epoch number
        /// </returns>
        public long epoch { get; set; }

        /// <summary>
        /// Gets or sets the EpochSlot
        /// </summary>
        /// <returns>
        /// Slot within the epoch
        /// </returns>
        public long epoch_slot { get; set; }

        /// <summary>
        /// Gets or sets the SlotLeader
        /// </summary>
        /// <returns>
        /// Bech32 ID of the slot leader or specific block description in case there is no slot leader
        /// </returns>
        public string slot_leader { get; set; }

        /// <summary>
        /// Gets or sets the Size
        /// </summary>
        /// <returns>
        /// Block size in Bytes
        /// </returns>
        public long size { get; set; }

        /// <summary>
        /// Gets or sets the TxCount
        /// </summary>
        /// <returns>
        /// Number of transactions in the block
        /// </returns>
        public long tx_count { get; set; }

        /// <summary>
        /// Gets or sets the Output
        /// </summary>
        /// <returns>
        /// Total output within the block in Lovelaces
        /// </returns>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the Fees
        /// </summary>
        /// <returns>
        /// Total fees within the block in Lovelaces
        /// </returns>
        public string fees { get; set; }

        /// <summary>
        /// Gets or sets the BlockVrf
        /// </summary>
        /// <returns>
        /// VRF key of the block
        /// </returns>
        public string block_vrf { get; set; }

        /// <summary>
        /// Gets or sets the PreviousBlock
        /// </summary>
        /// <returns>
        /// Hash of the previous block
        /// </returns>
        public string previous_block { get; set; }

        /// <summary>
        /// Gets or sets the NextBlock
        /// </summary>
        /// <returns>
        /// Hash of the next block
        /// </returns>
        public string next_block { get; set; }

        /// <summary>
        /// Gets or sets the Confirmations
        /// </summary>
        /// <returns>
        /// Number of block confirmations
        /// </returns>
        public long confirmations { get; set; }
    }
}