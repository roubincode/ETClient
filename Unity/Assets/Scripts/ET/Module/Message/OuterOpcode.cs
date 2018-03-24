namespace ETModel
{
	public static partial class OuterOpcode
	{
        public const ushort C2R_Login = 10001;
        public const ushort R2C_Login = 10002;
        public const ushort C2G_LoginGate = 10003;
        public const ushort G2C_LoginGate = 10004;
        public const ushort G2C_TestHotfixMessage = 10005;
        public const ushort C2M_TestActorRequest = 10006;
        public const ushort M2C_TestActorResponse = 10007;
        public const ushort PlayerInfo = 10008;
        public const ushort C2G_PlayerInfo = 10009;
        public const ushort G2C_PlayerInfo = 10010;

        public const ushort Actor_Test = 101;
        public const ushort Actor_TestRequest = 102;
        public const ushort Actor_TestResponse = 103;
        public const ushort Actor_TransferRequest = 104;
        public const ushort Actor_TransferResponse = 105;
        public const ushort C2G_EnterMap = 106;
        public const ushort G2C_EnterMap = 107;
        public const ushort UnitInfo = 108;
        public const ushort Actor_CreateUnits = 109;
        public const ushort OneFrameMessage = 110;
        public const ushort FrameMessage = 111;
        public const ushort Frame_ClickMap = 112;
        public const ushort C2M_Reload = 113;
        public const ushort M2C_Reload = 114;
        public const ushort C2R_Ping = 115;
        public const ushort R2C_Ping = 116;
	}
}
