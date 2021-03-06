// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: user_message.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using scg = global::System.Collections.Generic;
namespace UserMessage {

  #region Enums
  public enum opcode {
    None = 0,
    ReqNeedCallback = 1,
    ReqNoCallback = 2,
    AckNeedCallback = 3,
    AckNoCallback = 4,
    ClientHeartBeat = 5,
    ServerHeartBeat = 6,
  }

  #endregion

  #region Messages
  /// <summary>
  ///调用
  /// </summary>
  public sealed class call_data : pb::IMessage {
    private static readonly pb::MessageParser<call_data> _parser = new pb::MessageParser<call_data>(() => new call_data());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<call_data> Parser { get { return _parser; } }

    /// <summary>Field number for the "handle_name" field.</summary>
    public const int HandleNameFieldNumber = 1;
    private string handleName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HandleName {
      get { return handleName_; }
      set {
        handleName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "func_name" field.</summary>
    public const int FuncNameFieldNumber = 2;
    private string funcName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FuncName {
      get { return funcName_; }
      set {
        funcName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 3;
    private pb::ByteString data_ = pb::ByteString.Empty;
    /// <summary>
    ///data数据定义在以handle_name为package名, "req_"+func_name 为message名的结构中，如果是服务端推送消息，在以handle_name为package名, "push_"+func_name 为message名的结构中
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (HandleName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(HandleName);
      }
      if (FuncName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(FuncName);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Data);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HandleName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HandleName);
      }
      if (FuncName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FuncName);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            HandleName = input.ReadString();
            break;
          }
          case 18: {
            FuncName = input.ReadString();
            break;
          }
          case 26: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///回调
  /// </summary>
  public sealed class callback_data : pb::IMessage {
    private static readonly pb::MessageParser<callback_data> _parser = new pb::MessageParser<callback_data>(() => new callback_data());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<callback_data> Parser { get { return _parser; } }

    /// <summary>Field number for the "r" field.</summary>
    public const int RFieldNumber = 1;
    private uint r_;
    /// <summary>
    ///1表示成功 其他失败
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint R {
      get { return r_; }
      set {
        r_ = value;
      }
    }

    /// <summary>Field number for the "d" field.</summary>
    public const int DFieldNumber = 2;
    private pb::ByteString d_ = pb::ByteString.Empty;
    /// <summary>
    ///d数据定义在以其对应req的handle_name为package名, "rsp_"+func_name 为message名的结构中
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString D {
      get { return d_; }
      set {
        d_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "msg" field.</summary>
    public const int MsgFieldNumber = 3;
    private string msg_ = "";
    /// <summary>
    ///r!= 1时错误提示信息
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Msg {
      get { return msg_; }
      set {
        msg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ts" field.</summary>
    public const int TsFieldNumber = 4;
    private ulong ts_;
    /// <summary>
    ///时间戳
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong Ts {
      get { return ts_; }
      set {
        ts_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (R != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(R);
      }
      if (D.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(D);
      }
      if (Msg.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Msg);
      }
      if (Ts != 0UL) {
        output.WriteRawTag(32);
        output.WriteUInt64(Ts);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (R != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(R);
      }
      if (D.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(D);
      }
      if (Msg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Msg);
      }
      if (Ts != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(Ts);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            R = input.ReadUInt32();
            break;
          }
          case 18: {
            D = input.ReadBytes();
            break;
          }
          case 26: {
            Msg = input.ReadString();
            break;
          }
          case 32: {
            Ts = input.ReadUInt64();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///消息
  /// </summary>
  public sealed class user_message : pb::IMessage {
    private static readonly pb::MessageParser<user_message> _parser = new pb::MessageParser<user_message>(() => new user_message());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<user_message> Parser { get { return _parser; } }

    /// <summary>Field number for the "opcode" field.</summary>
    public const int OpcodeFieldNumber = 1;
    private global::UserMessage.opcode opcode_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UserMessage.opcode Opcode {
      get { return opcode_; }
      set {
        opcode_ = value;
      }
    }

    /// <summary>Field number for the "message_id" field.</summary>
    public const int MessageIdFieldNumber = 2;
    private uint messageId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MessageId {
      get { return messageId_; }
      set {
        messageId_ = value;
      }
    }

    /// <summary>Field number for the "call" field.</summary>
    public const int CallFieldNumber = 3;
    private global::UserMessage.call_data call_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UserMessage.call_data Call {
      get { return call_; }
      set {
        call_ = value;
      }
    }

    /// <summary>Field number for the "callback" field.</summary>
    public const int CallbackFieldNumber = 4;
    private global::UserMessage.callback_data callback_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UserMessage.callback_data Callback {
      get { return callback_; }
      set {
        callback_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Opcode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Opcode);
      }
      if (MessageId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(MessageId);
      }
      if (call_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Call);
      }
      if (callback_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Callback);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Opcode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Opcode);
      }
      if (MessageId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MessageId);
      }
      if (call_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Call);
      }
      if (callback_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Callback);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            opcode_ = (global::UserMessage.opcode) input.ReadEnum();
            break;
          }
          case 16: {
            MessageId = input.ReadUInt32();
            break;
          }
          case 26: {
            if (call_ == null) {
              call_ = new global::UserMessage.call_data();
            }
            input.ReadMessage(call_);
            break;
          }
          case 34: {
            if (callback_ == null) {
              callback_ = new global::UserMessage.callback_data();
            }
            input.ReadMessage(callback_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
