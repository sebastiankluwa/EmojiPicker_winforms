using EmojiPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiPicker.Interfaces
{
    interface IEmojiManager
    {
        public List<Emoji> getAllEmojis();
        public List<Emoji> getEmojiGroup(String groupID);
        public void addToEmojiGroup(String groupID, List<Emoji> emojis);
        public void addEmojiGroup(String groupID, List<Emoji> groupEmojis);
        public void removeEmojiGroup(String groupID);
        public void removeEmojiFromGroup(String groupID, Emoji emoji);
        public List<String> getEmojiGroupIDs();
    }
}
