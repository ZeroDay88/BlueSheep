









// Generated on 12/11/2014 19:01:43
using System;
using System.Collections.Generic;
using System.Linq;
using BlueSheep.Common.Protocol.Types;
using BlueSheep.Common.IO;
using BlueSheep.Engine.Types;

namespace BlueSheep.Common.Protocol.Messages
{
    public class GuildMemberSetWarnOnConnectionMessage : Message
    {
        public new const uint ID =6159;
        public override uint ProtocolID
        {
            get { return ID; }
        }
        
        public bool enable;
        
        public GuildMemberSetWarnOnConnectionMessage()
        {
        }
        
        public GuildMemberSetWarnOnConnectionMessage(bool enable)
        {
            this.enable = enable;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteBoolean(enable);
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            enable = reader.ReadBoolean();
        }
        
    }
    
}