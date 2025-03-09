using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
	public class OldPhonePadMain{
        public static void Main(string[] args) { 
            // Provided Test Cases
            Console.WriteLine($"OldPhonePad(\"33#\") => {OldPhonePad("33#")}"); // Expected: "E"
            Console.WriteLine($"OldPhonePad(\"227*#\") => {OldPhonePad("227*#")}"); // Expected: "B"
            Console.WriteLine($"OldPhonePad(\"4433555 555666#\") => {OldPhonePad("4433555 555666#")}"); // Expected: "HELLO"
            Console.WriteLine($"OldPhonePad(\"8 88777444666*664#\") => {OldPhonePad("8 88777444666*664#")}"); // Expected: "TURING"

            // Additional Test Cases
            Console.WriteLine($"OldPhonePad(\"#\") => {OldPhonePad("#")}"); // Empty input, expected: ""
            Console.WriteLine($"OldPhonePad(\"111#\") => {OldPhonePad("111#")}"); // Expected: "("
            Console.WriteLine($"OldPhonePad(\"7777#\") => {OldPhonePad("7777#")}"); // Expected: "S"
            Console.WriteLine($"OldPhonePad(\"2*2#\") => {OldPhonePad("2*2#")}"); // Expected: "A"
            Console.WriteLine($"OldPhonePad(\"22222#\") => {OldPhonePad("22222#")}"); // Expected: "B"
            Console.WriteLine($"OldPhonePad(\"***#\") => {OldPhonePad("***#")}"); // Only backspaces, expected: ""
            Console.WriteLine
            ($"OldPhonePad(\"444777666 66022266634446640222442555 5553366433#\") => {OldPhonePad("444777666 66022266634446640222442555 5553366433#")}"); // Expected: "IRON CODING CHALLENGE"
        }



        /// <summary>
        /// Converts an input string into text based on old mobile phone keypads.
        /// </summary>
        /// <param name="input">The keypad sequence.</param>
        /// <returns>The converted text output.</returns>
        public static string OldPhonePad(string input){
            
            // Dictionary mapping keys to their respective character sets.
            Dictionary<char, string> keys = new Dictionary<char, string> 
            {{'1', "&'("}, {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"},
             {'6', "MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"}, {'0', " "}};

            StringBuilder output = new StringBuilder();
            int count = 0;
            char lastChar = '~';

            /// <summary>
            /// Converts the last pressed key into the corresponding character based on the press count.
            /// </summary>
            void convertKeyToCharacter()
            {
                if (count > 0 && keys.ContainsKey(lastChar)){
                    string letters = keys[lastChar];
                    if (letters != "")
                    {
                        output.Append(letters[(count - 1) % letters.Length]);
                    }
                }
            }

            // Process each key of the input sequence.
            for (int i = 0; i < input.Length; i++){

                char curChar = input[i];

                if (curChar == ' ' || curChar == '#'){

                    // Convert the previously pressed key before the process is stopped.
                    convertKeyToCharacter();

                    // '#' indicates the end of input; stop processing.
                    if (curChar == '#'){
                        break;
                    }

                    // Space resets the key press count due to a time gap.
                    else{
                        count = 0;
                        lastChar = '~';
                        continue;
                    }
                }

                // If the same key is pressed consecutively, increase the count.
                if (curChar == lastChar){
                    count++;
                }
                // Convert the previous key before moving to a new key.
                else{
                    convertKeyToCharacter();
                    count = 1;
                    lastChar = curChar;
                }

                // If the key "*" is pressed, remove the one last character by reducing the length of output string.(backspace function)
                if (curChar == '*'){
                    if (output.Length > 0){
                        output.Length--;
                    }
                    lastChar = '~';
                    continue;
                }

            }

            return output.ToString();
        }
    }
}
