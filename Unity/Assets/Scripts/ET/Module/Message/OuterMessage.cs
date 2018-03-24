using ProtoBuf;
using ETModel;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
namespace ETModel
{
    [Message(OuterOpcode.C2R_Login)]
    [ProtoContract]
    public partial class C2R_Login : IRequest
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public string Account;

        [ProtoMember(2, IsRequired = true)]
        public string Password;

    }

    [Message(OuterOpcode.R2C_Login)]
    [ProtoContract]
    public partial class R2C_Login : IResponse
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(91, IsRequired = true)]
        public int Error { get; set; }

        [ProtoMember(92, IsRequired = true)]
        public string Message { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public string Address;

        [ProtoMember(2, IsRequired = true)]
        public long Key;

    }

    [Message(OuterOpcode.C2G_LoginGate)]
    [ProtoContract]
    public partial class C2G_LoginGate : IRequest
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public long Key;

    }

    [Message(OuterOpcode.G2C_LoginGate)]
    [ProtoContract]
    public partial class G2C_LoginGate : IResponse
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(91, IsRequired = true)]
        public int Error { get; set; }

        [ProtoMember(92, IsRequired = true)]
        public string Message { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public long PlayerId;

    }

    [Message(OuterOpcode.G2C_TestHotfixMessage)]
    [ProtoContract]
    public partial class G2C_TestHotfixMessage : IMessage
    {
        [ProtoMember(1, IsRequired = true)]
        public string Info;

    }

    [Message(OuterOpcode.C2M_TestActorRequest)]
    [ProtoContract]
    public partial class C2M_TestActorRequest : IActorRequest
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(93, IsRequired = true)]
        public long ActorId { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public string Info;

    }

    [Message(OuterOpcode.M2C_TestActorResponse)]
    [ProtoContract]
    public partial class M2C_TestActorResponse : IActorResponse
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(91, IsRequired = true)]
        public int Error { get; set; }

        [ProtoMember(92, IsRequired = true)]
        public string Message { get; set; }

        [ProtoMember(1, IsRequired = true)]
        public string Info;

    }

    [Message(OuterOpcode.PlayerInfo)]
    [ProtoContract]
    public partial class PlayerInfo : IMessage
    {
    }

    [Message(OuterOpcode.C2G_PlayerInfo)]
    [ProtoContract]
    public partial class C2G_PlayerInfo : IRequest
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

    }

    [Message(OuterOpcode.G2C_PlayerInfo)]
    [ProtoContract]
    public partial class G2C_PlayerInfo : IResponse
    {
        [ProtoMember(90, IsRequired = true)]
        public int RpcId { get; set; }

        [ProtoMember(91, IsRequired = true)]
        public int Error { get; set; }

        [ProtoMember(92, IsRequired = true)]
        public string Message { get; set; }

        [ProtoMember(1, TypeName = "ETModel.PlayerInfo")]
        public List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();

    }

    [Message(OuterOpcode.Actor_Test)]
	[ProtoContract]
	public partial class Actor_Test: IActorMessage
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public string Info;

	}

	[Message(OuterOpcode.Actor_TestRequest)]
	[ProtoContract]
	public partial class Actor_TestRequest: IActorRequest
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public string request;

	}

	[Message(OuterOpcode.Actor_TestResponse)]
	[ProtoContract]
	public partial class Actor_TestResponse: IActorResponse
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(91, IsRequired = true)]
		public int Error { get; set; }

		[ProtoMember(92, IsRequired = true)]
		public string Message { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public string response;

	}

	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: IActorRequest
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public int MapIndex;

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: IActorResponse
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(91, IsRequired = true)]
		public int Error { get; set; }

		[ProtoMember(92, IsRequired = true)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: IRequest
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: IResponse
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(91, IsRequired = true)]
		public int Error { get; set; }

		[ProtoMember(92, IsRequired = true)]
		public string Message { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public long UnitId;

		[ProtoMember(2, IsRequired = true)]
		public int Count;

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo
	{
		[ProtoMember(1, IsRequired = true)]
		public long UnitId;

		[ProtoMember(2, IsRequired = true)]
		public int X;

		[ProtoMember(3, IsRequired = true)]
		public int Z;

	}

	[Message(OuterOpcode.Actor_CreateUnits)]
	[ProtoContract]
	public partial class Actor_CreateUnits: IActorMessage
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, TypeName = "ETModel.UnitInfo")]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.OneFrameMessage)]
	[ProtoContract]
	public partial class OneFrameMessage: IActorMessage
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public ushort Op;

		[ProtoMember(2, IsRequired = true)]
		public byte[] AMessage;

	}

	[Message(OuterOpcode.FrameMessage)]
	[ProtoContract]
	public partial class FrameMessage: IActorMessage
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(93, IsRequired = true)]
		public long ActorId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public int Frame;

		[ProtoMember(2, TypeName = "ETModel.OneFrameMessage")]
		public List<OneFrameMessage> Messages = new List<OneFrameMessage>();

	}

	[Message(OuterOpcode.Frame_ClickMap)]
	[ProtoContract]
	public partial class Frame_ClickMap: IFrameMessage
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(94, IsRequired = true)]
		public long Id { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public int X;

		[ProtoMember(2, IsRequired = true)]
		public int Z;

	}

	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: IRequest
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(1, IsRequired = true)]
		public AppType AppType;

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: IResponse
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(91, IsRequired = true)]
		public int Error { get; set; }

		[ProtoMember(92, IsRequired = true)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.C2R_Ping)]
	[ProtoContract]
	public partial class C2R_Ping: IRequest
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.R2C_Ping)]
	[ProtoContract]
	public partial class R2C_Ping: IResponse
	{
		[ProtoMember(90, IsRequired = true)]
		public int RpcId { get; set; }

		[ProtoMember(91, IsRequired = true)]
		public int Error { get; set; }

		[ProtoMember(92, IsRequired = true)]
		public string Message { get; set; }

	}

}
