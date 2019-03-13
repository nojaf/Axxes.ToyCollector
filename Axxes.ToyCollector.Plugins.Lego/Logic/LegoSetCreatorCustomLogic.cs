using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Axxes.ToyCollector.Core.Contracts.Services;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.Plugins.Lego.Models;

namespace Axxes.ToyCollector.Plugins.Lego.Logic
{
    public class LegoSetCreatorCustomLogic : IToyCreatorCustomLogic<LegoSet>
    {
        public void Execute(Toy newToy)
        {
            if (newToy is LegoSet set)
            {
                WriteLegoToConsole();
            }
        }

        private void WriteLegoToConsole()
        {
            var logoText = ReadEmbeddedResource("logo.txt").ToCharArray();
            for (int i = 0; i < logoText.Length; i++)
            {
                switch (logoText[i])
                {
                    case '\'':
                        WriteInColor(ConsoleColor.Red, logoText[i]);
                        break;
                    case ' ':
                        WriteInColor(ConsoleColor.White, '.');
                        break;
                   default:
                        WriteInColor(ConsoleColor.Black, logoText[i]);
                        break;
                }
            }
        }

        private static string ReadEmbeddedResource(string resourceName)
        {
            var assembly = typeof(LegoSetCreatorCustomLogic).Assembly;
            var resourceFile = assembly.GetManifestResourceNames().First(x => x.Contains(resourceName));
            using (var stream = assembly.GetManifestResourceStream(resourceFile))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static void WriteInColor(ConsoleColor color, char character)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = prevColor;
        }
    }
}