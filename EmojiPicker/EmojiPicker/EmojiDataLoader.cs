using EmojiPicker.Interfaces;
using EmojiPicker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmojiPicker
{
    public class EmojiDataLoader : IEmojiDataLoader
    {
        private string dataFilePath;

        public EmojiDataLoader(string? dataFilePath)
        {
            this.dataFilePath = dataFilePath;
        }

        public void loadEmojiData(IEmojiManager emojiManager)
        {
            try
            {
                if(new FileInfo(dataFilePath).Exists)
                {
                    throw new FileNotFoundException($"Could not open emoji data file from: {dataFilePath}");
                }

                List<string> lines = linesFromFileAsList();
                List<SerializedEmojiGroup> assembled = assembleSerialisedEmojiGroups(lines);
                //List<EmojiGroup> deserialised = deserialiseEmojiGroups(assembled);

            }
            catch (Exception)
            {

                throw;
            }

            //    List<EmojiGroup> deserialised = deserialiseEmojiGroups(assembled);

            //    for (EmojiGroup emojiGroup: deserialised)
            //    {
            //        emojiManager.addToEmojiGroup(emojiGroup.groupID, emojiGroup.emojis);
            //    }
            //}
            //catch (FileNotFoundException eFnf)
            //{
            //    showMissingEmojiDataFileDialog();
            //    JOptionPane.showMessageDialog(null, "");
            //}
            //catch (IOException eIo)
            //{
            //    showIOExceptionDialog();
            //}
        }

        private List<string> linesFromFileAsList()
        {
            var lines = File.ReadAllLines(dataFilePath);
            return lines.ToList();
        }

        private List<SerializedEmojiGroup> assembleSerialisedEmojiGroups(List<String> lines)
        {
            List<SerializedEmojiGroup> groups = new List<SerializedEmojiGroup>();
            SerializedEmojiGroup currentGroup = new SerializedEmojiGroup();
            currentGroup.groupNameLine = "# group: Ungrouped";
            foreach (var line in lines)
            {
                if (isGroupNameLine(line))
                {
                    groups.Add(currentGroup);
                    currentGroup = new SerializedEmojiGroup();
                    currentGroup.groupNameLine = line;
                }
                else if (isDataLine(line))
                {
                    currentGroup.dataLines.Add(line);
                }
                else continue;
            }
            groups.Add(currentGroup);
            return groups;
        }

        private bool isGroupNameLine(string line)
        {
            string pattern = @"#\\s*group:.*";
            return Regex.IsMatch(line, pattern, RegexOptions.IgnoreCase);
        }

        private bool isDataLine(String line)
        {
            string pattern = @"[^#].+;.+";
            return Regex.IsMatch(line, pattern);
        }

        //private List<EmojiGroup> deserialiseEmojiGroups(List<SerializedEmojiGroup> serialisedEmojiGroups)
        //{
        //    List<EmojiGroup> deserialisedGroups = new LinkedList<>();

        //    for (SerializedEmojiGroup serialisedGroup: serialisedEmojiGroups)
        //    {
        //        EmojiGroup deserialisedGroup = new EmojiGroup();

        //        // Parse the group name line.
        //        String[] groupNameLineFields =
        //                serialisedGroup.groupNameLine.split(":", 2);
        //        assert groupNameLineFields.length == 2;
        //        deserialisedGroup.groupID = groupNameLineFields[1].trim();

        //        // Parse each com.app.data line.
        //        for (String dataLine: serialisedGroup.dataLines)
        //        {
        //            String[] dataLineFields = dataLine
        //                    .replaceAll("#[^#]*$", "") // Remove EOL comment
        //                    .split(";");
        //            assert dataLineFields.length == 2;

        //            String status = dataLineFields[1].trim();
        //            if (!status.equals("fully-qualified"))
        //            {
        //                // We ignore emoji sequences that aren't fully qualified.
        //                continue;
        //            }

        //            String[] serialisedCodePoints = dataLineFields[0].split("\\s+");
        //            StringBuilder qualifiedSequenceBuilder = new StringBuilder();
        //            for (String serialisedCodePoint: serialisedCodePoints)
        //            {
        //                int deserialisedCodePoint =
        //                        parseUnicodeScalar(serialisedCodePoint);
        //                qualifiedSequenceBuilder
        //                        .append(Character.toChars(deserialisedCodePoint));
        //            }

        //            Emoji emoji = new Emoji();
        //            emoji.qualifiedSequence = qualifiedSequenceBuilder.toString();
        //            deserialisedGroup.emojis.add(emoji);
        //        }

        //        deserialisedGroups.add(deserialisedGroup);
        //    }

        //    return deserialisedGroups;
        //}
    }
}