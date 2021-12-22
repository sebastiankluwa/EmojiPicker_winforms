using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiPicker.Models
{
    public class SerializedEmojiGroup
    {
        public string groupNameLine { get; set; }
        public List<string> dataLines { get; set; } = new List<string>();
    }
}
