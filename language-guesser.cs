using System;

namespace LanguageGuesser {
    class App {
        public static Dictionary<Language, string> languages;
        
        public static void Main(string[] args) {
            languages = new Dictionary<Language, string>();
            languages.Add(new Language("b", "b", "a", "b"), "Java");
            languages.Add(new Language("b", "b", "b", "b"), "C#");
            
            Console.WriteLine("Where is your language initialized? Is it (a) int main, (b) public static void main, or (c) at the start of your file?");
            string init = Console.ReadLine();
            Console.WriteLine("How does your language do blocks? Is it (a) with curly braces and do/end, (b) with only curly braces, or (c) with indentation?");
            string block = Console.ReadLine();
            Console.WriteLine("What implicit typing does your language have? Is the simplest way to define a variable (a) with the type of the variable and then the name, (b) with a keyword such as var and then the name, or (c) with just the name?");
            string vardef = Console.ReadLine();
            Console.WriteLine("What word is used to refer to instance variables and inside a class? Is it (a) self or (b) this?");
            string classword = Console.ReadLine();
            
            var correctLanguage = "";
            foreach (var language in languages) {
                Language dat = language.Key;
                string lang = language.Value;
                if (dat.LanguageCorrect(init, block, vardef, classword)) {
                    correctLanguage = lang;
                }
            }
            if (correctLanguage == "") {
                Console.WriteLine("I do not know this language.");
            } else {
                Console.WriteLine("I think your language is "+correctLanguage);
            }
        }
    }
    class Language {
        public string init;
        public string block;
        public string vardef;
        public string classword
        
        Language(string init, string block, string vardef, string classword) {
            this.init = init;
            this.block = block;
            this.vardef = vardef;
            this.classword = classword;
        }
        
        public LanguageCorrect(string init, string block, string vardef, string classword) {
            return this.init == init && this.block == block && this.vardef == vardef && this.classword == classword;
        }
    }
}
