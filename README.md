# OldPhonePad Coding Challenge

# Overview
This program converts button presses from an old mobile phone keypad into text. It follows the same typing rules used on classic phones.

# How It Works
Digits (1-9) → Corresponding letters (e.g., 1 = &'(, 2 = ABC, 3 = DEF).
"0" → Space.
"*" → Backspace (deletes the last character).
"#" → End input and return the final text.

# Example Input & Output
string input = "4433555 555666096667775553#";
Console.WriteLine(OldPhonePad(input));  
// Output: "HELLO WORLD"


# Setup & Run

Prerequisites
    .NET 8.0 SDK (or later)
    Visual Studio 2022 (or any compatible IDE)

Steps
    Clone the repository: git clone https://github.com/KhamNCAg/CSharp_Coding_Challenge.git
    Open the project in Visual Studio or any compatible IDE.
    Build & Run