using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiPicker.Interfaces
{
    public interface IEmojiDataLoader
    {
        public void loadEmojiData(IEmojiManager emojiManager);
    }
}
