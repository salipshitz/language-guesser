using System;
using System.Collections.Generic;

namespace LanguageGuesser {
    class App {
        public static Dictionary<string, Language> languages;
        
        public static void Main(string[] args) {
            languages = new Dictionary<string, Language>();
            languages.Add("Java", new Language("b", "b", "a", "b"));
            languages.Add("C#", new Language("b", "b", "b", "b"));
            languages.Add("Python", new Language("c", "c", "c", "a"));
            languages.Add("Ruby", new Language("c", "a", "c", "a"));
            languages.Add("Javascript", new Language("c", "b", "b", "b"));
            languages.Add("C", new Language("a", "b", "a", "c"));
            languages.Add("C++", new Language("a", "b", "a", "a"));
            languages.Add("", new Language("a", "b", "b", "a"));

            Console.WriteLine("Where is your language initialized? Is it (a) int main, (b) public static void main, (c) at the start of your file, or (d) none of the above?");
            string init = Console.ReadLine();
            Console.WriteLine("How does your language do blocks? Is it (a) with curly braces and do/end, (b) with only curly braces, or (c) with indentation?");
            string block = Console.ReadLine();
            Console.WriteLine("What implicit typing does your language have? Is the simplest way to define a variable (a) with the type of the variable and then the name, (b) with a keyword such as var and then the name, or (c) with just the name?");
            string vardef = Console.ReadLine();
            Console.WriteLine("What word is used to refer to instance variables and inside a class? Is it (a) self or (b) this, or (c) are there no classes?");
            string classword = Console.ReadLine();
            
            var correctLanguage = "";
            foreach (var language in languages) {
                var dat = language.Value;
                var lang = language.Key;
                if (dat.LanguageCorrect(init, block, vardef, classword))
                    correctLanguage = lang;
            }
            if (correctLanguage == "") {
                Console.WriteLine("I do not know this language.");
                Console.WriteLine("What language is this? (capitalize the first letter)");
                correctLanguage = Console.ReadLine();
                foreach (var val in languages) {
                    var lang = val.Key;
                    var dat = val.Value;
                    if (correctLanguage == lang) {
                        Console.WriteLine("According to my dataase, you got your info wrong.");
                        Console.WriteLine("The answer to the first question was {0} and you answered {1}", dat.init, init);
                        Console.WriteLine("The answer to the second question was {0} and you answered {1}", dat.block, block);
                        Console.WriteLine("The answer to the third question was {0} and you answered {1}", dat.vardef, vardef);
                        Console.WriteLine("The answer to the fourth question was {0} and you answered {1}", dat.classword, classword);
                        /*Console.Write("Do you want to update the value? (y/N)");
                        while (true) {
                            var k = Console.ReadKey().KeyChar;
                            if (k.ToLower == 'y') {
                                languages[lang] = dat;
                                break;
                            } if (k.ToUpper == 'N') {
                                break;
                            }
                        }*/
                    } else {
                        /*Console.Write("Do you want to add this language? (Y/n)");
                        while (true) {
                            var k = Console.ReadKey().KeyChar;
                            if (k.ToUpper == 'Y') {
                                languages.Add(lang, dat);
                                break;
                            } if (k.ToLower == 'n') {
                                break;
                            }
                        }*/
                    }
                }
            } else {
                Console.WriteLine("I think your language is "+correctLanguage);
            }
        }
    }
    class Language {
        public string init;
        public string block;
        public string vardef;
        public string classword;
        
        public Language(string init, string block, string vardef, string classword) {
            this.init = init;
            this.block = block;
            this.vardef = vardef;
            this.classword = classword;
        }
        
        public bool LanguageCorrect(string init, string block, string vardef, string classword) {
            return this.init == init && this.block == block && this.vardef == vardef && this.classword == classword;
        }
    }
}
