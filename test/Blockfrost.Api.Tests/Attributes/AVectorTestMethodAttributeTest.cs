// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

namespace Blockfrost.Api.Tests.Attributes
{
    public abstract class AVectorTestMethodAttributeTest
    {
        public const string V_01 = "01";
        public const string DOES_NOT_EXIST = "DOES_NOT_EXIST";
        public const string REFERENCE_DRAFT = "reference.draft";
        public const string REFERENCE_DRAFT_RAW = "reference.draft.raw";
        public const string REFERENCE_SIGNED = "reference.signed";
        public const string REFERENCE_SIGNED_RAW = "reference.signed.raw";
        public const string TX_DRAFT = "tx.draft";
        public const string TX_DRAFT_RAW = "tx.draft.raw";
        public const string TX_SIGNED = "tx.signed";
        public const string TX_SIGNED_RAW = "tx.signed.raw";
        public const string ALL_SUPPORTED_FILENAMES = TX_DRAFT + "," + TX_DRAFT_RAW + "," + TX_SIGNED + "," + TX_SIGNED_RAW + "," + REFERENCE_DRAFT + "," + REFERENCE_DRAFT_RAW + "," + REFERENCE_SIGNED + "," + REFERENCE_SIGNED_RAW;
    }
}
