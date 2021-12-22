using EmojiPicker.Interfaces;
using EmojiPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiPicker
{
    public class EmojiManager : IEmojiManager
    {
        private Dictionary<String, List<Emoji>> emojiGroups;

        public EmojiManager()
        {
            emojiGroups = new Dictionary<String, List<Emoji>>();
        }

        public void addEmojiGroup(string groupID, List<Emoji> groupEmojis)
        {
            if (groupID != null && groupEmojis != null)
                emojiGroups.Add(groupID, groupEmojis);
        }

        public void addToEmojiGroup(string groupID, List<Emoji> emojis)
        {
            if(groupID != null && emojis != null && emojis.Count > 0)
            {
                List<Emoji> group = emojiGroups.GetValueOrDefault(groupID);
                if(group == null)
                {
                    group = new List<Emoji> ();
                }
                group.AddRange(emojis);
                emojiGroups.Add(groupID, group);
            }
        }

        public List<Emoji> getAllEmojis()
        {
            List<Emoji> returnee = new List<Emoji>();
            foreach (var categoryEmojis in emojiGroups.Values)
            {
                returnee.AddRange(categoryEmojis);
            }
            return returnee;
        }

        public List<Emoji> getEmojiGroup(string groupID)
        {
            if (!String.IsNullOrEmpty(groupID))
            {
                List<Emoji> groupEmojis = emojiGroups.GetValueOrDefault(groupID);
                return groupEmojis;
            }
            return new List<Emoji>();
        }

        public List<string> getEmojiGroupIDs()
        {
            return emojiGroups.Keys.ToList();
        }

        public void removeEmojiFromGroup(string groupID, Emoji emoji)
        {
            if(!String.IsNullOrEmpty(groupID) && emoji != null)
            {
                var categoryEmojis = emojiGroups.GetValueOrDefault(groupID);
                categoryEmojis.Remove(emoji);

                emojiGroups.Add(groupID, categoryEmojis);
            }
        }

        public void removeEmojiGroup(string groupID)
        {
            if(String.IsNullOrEmpty(groupID))
                emojiGroups.Remove(groupID);
        }


    }
}
