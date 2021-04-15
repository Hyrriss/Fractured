using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Fractured.World;

namespace Fractured.Logic
{
    public class ProcessText
    {
        private readonly string[] FLines;
        private readonly List<Script> Effects;
        private int PrimaryMarkdownEffect;
        private int SecondaryMarkdownEffect;
        private int _portraitID;
        private int _sfxID;
        private int _talkCharID;
        private int _portCharID;
        private int _cgiID;
        private int _locID;

        public ProcessText(string filePath)
        {
            _portraitID = 0;
            _sfxID = 0;
            _talkCharID = 0;
            _portCharID = 0;
            _cgiID = 0;
            _locID = 0;
            Effects = new List<Script>();
            FLines = LoadTextAsset(filePath);
            foreach (string f in FLines)
            {
                string txt = null;
                foreach (char c in f)
                {
                    if (c != '$') { txt += c; }
                    else{ MarkdownCheck(f); break; }
                }
                if (txt != null || _locID != 0)
                    Effects.Add(SetValues(txt, _talkCharID, _portCharID, _portraitID, _sfxID, _cgiID, _locID));
            }
        }

        private string[] LoadTextAsset(string filePath)
        {
            using var stream = TitleContainer.OpenStream(filePath);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd().Split('\n');
        }

        private void MarkdownCheck(string f)
        {
            for(int i = 1; i < f.Length; i++)
            {
                int.TryParse($"{f[i + 1]}{f[i + 2]}", out PrimaryMarkdownEffect);
                int.TryParse($"{f[i + 3]}{f[i + 4]}", out SecondaryMarkdownEffect);

                switch (f[i])
                {
                    case 'c':
                        _talkCharID = PrimaryMarkdownEffect;
                        i += 2;
                        break;
                    case 'p':
                        _talkCharID = _portCharID = PrimaryMarkdownEffect;
                        _portraitID = SecondaryMarkdownEffect;
                        i += 4;
                        break;
                    case 'g':
                        _cgiID = PrimaryMarkdownEffect;
                        i += 2;
                        break;
                    case 'f':
                        _sfxID = PrimaryMarkdownEffect;
                        i += 2;
                        break;
                    case 'l':
                        _locID = PrimaryMarkdownEffect;
                        i += 2;
                        break;
                    default:
                        break;
                }
            }
        }

        private Script SetValues(string text, int charID, int portCharID, int portID, int sfxID, int cgiID, int locID)
        {
            return new Script
            {
                text = text,
                characterTalking = Global.GetCharFromID(charID),
                portraitCharacter = Global.GetCharFromID(portCharID),
                portraitID = portID,
                soundEffect = sfxID,
                renderedImage = cgiID,
                Destination = Global.GetLocFromID(locID)
            };
        }
    }
}
