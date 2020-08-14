using System;
using System.Collections.Generic;
using UnityEngine;

namespace KeyInputII.EditorOnly
{
    /// <summary>
    /// デフォルトのInput文字列を変換するクラス
    /// </summary>
    public static class DefaultInputKeyNameConverter
    {
        /// <summary>
        /// デフォルトのInputSystemに使うKeyCodeと文字列の対応辞書
        /// </summary>
        private readonly static Dictionary<KeyCode, string[]> KeyCodeConvertDict = new Dictionary<KeyCode, string[]>()
        {
            {KeyCode.None, new string[]{""}},
            {KeyCode.Backspace, new string[]{"backspace"}},
            {KeyCode.Delete, new string[]{"delete"}},
            {KeyCode.Tab, new string[]{"tab"}},
            {KeyCode.Clear, new string[]{"clear"}},
            {KeyCode.Return, new string[]{"return", "enter"}},
            {KeyCode.Pause, new string[]{"pause"}},
            {KeyCode.Escape, new string[]{"escape"}},
            {KeyCode.Space, new string[]{"space"}},
            {KeyCode.Keypad0, new string[]{"[0]"}},
            {KeyCode.Keypad1, new string[]{"[1]"}},
            {KeyCode.Keypad2, new string[]{"[2]"}},
            {KeyCode.Keypad3, new string[]{"[3]"}},
            {KeyCode.Keypad4, new string[]{"[4]"}},
            {KeyCode.Keypad5, new string[]{"[5]"}},
            {KeyCode.Keypad6, new string[]{"[6]"}},
            {KeyCode.Keypad7, new string[]{"[7]"}},
            {KeyCode.Keypad8, new string[]{"[8]"}},
            {KeyCode.Keypad9, new string[]{"[9]"}},
            {KeyCode.KeypadPeriod, new string[]{"[.]"}},
            {KeyCode.KeypadDivide, new string[]{"[/]"}},
            {KeyCode.KeypadMultiply, new string[]{"[*]"}},
            {KeyCode.KeypadMinus, new string[]{"[=]"}},
            {KeyCode.KeypadPlus, new string[]{"[+]"}},
            {KeyCode.KeypadEnter, new string[]{"[enter]"}},
            {KeyCode.KeypadEquals, new string[]{"[=]"}},
            {KeyCode.UpArrow, new string[]{"up"}},
            {KeyCode.DownArrow, new string[]{"down"}},
            {KeyCode.RightArrow, new string[]{"right"}},
            {KeyCode.LeftArrow, new string[]{"left"}},
            {KeyCode.Insert, new string[]{"insert"}},
            {KeyCode.Home, new string[]{"home"}},
            {KeyCode.End, new string[]{"end"}},
            {KeyCode.PageUp, new string[]{"page up"}},
            {KeyCode.PageDown, new string[]{"page down"}},
            {KeyCode.F1, new string[]{"f1"}},
            {KeyCode.F2, new string[]{"f2"}},
            {KeyCode.F3, new string[]{"f3"}},
            {KeyCode.F4, new string[]{"f4"}},
            {KeyCode.F5, new string[]{"f5"}},
            {KeyCode.F6, new string[]{"f6"}},
            {KeyCode.F7, new string[]{"f7"}},
            {KeyCode.F8, new string[]{"f8"}},
            {KeyCode.F9, new string[]{"f9"}},
            {KeyCode.F10, new string[]{"f10"}},
            {KeyCode.F11, new string[]{"f11"}},
            {KeyCode.F12, new string[]{"f12"}},
            {KeyCode.F13, new string[]{"f13"}},
            {KeyCode.F14, new string[]{"f14"}},
            {KeyCode.F15, new string[]{"f15"}},
            {KeyCode.Alpha0, new string[]{"0"}},
            {KeyCode.Alpha1, new string[]{"1"}},
            {KeyCode.Alpha2, new string[]{"2"}},
            {KeyCode.Alpha3, new string[]{"3"}},
            {KeyCode.Alpha4, new string[]{"4"}},
            {KeyCode.Alpha5, new string[]{"5"}},
            {KeyCode.Alpha6, new string[]{"6"}},
            {KeyCode.Alpha7, new string[]{"7"}},
            {KeyCode.Alpha8, new string[]{"8"}},
            {KeyCode.Alpha9, new string[]{"9"}},
            {KeyCode.Exclaim, new string[]{"!"}},
            {KeyCode.DoubleQuote, new string[]{"\""}},
            {KeyCode.Hash, new string[]{"#"}},
            {KeyCode.Dollar, new string[]{"$"}},
            {KeyCode.Ampersand, new string[]{"&"}},
            {KeyCode.Quote, new string[]{"\'"}},
            {KeyCode.LeftParen, new string[]{"("}},
            {KeyCode.RightParen, new string[]{")"}},
            {KeyCode.Asterisk, new string[]{"*"}},
            {KeyCode.Plus, new string[]{"+"}},
            {KeyCode.Comma, new string[]{","}},
            {KeyCode.Minus, new string[]{"="}},
            {KeyCode.Period, new string[]{"."}},
            {KeyCode.Slash, new string[]{"/"}},
            {KeyCode.Colon, new string[]{":"}},
            {KeyCode.Semicolon, new string[]{";"}},
            {KeyCode.Less, new string[]{"<"}},
            {KeyCode.Equals, new string[]{"="}},
            {KeyCode.Greater, new string[]{">"}},
            {KeyCode.Question, new string[]{"?"}},
            {KeyCode.At, new string[]{"@"}},
            {KeyCode.LeftBracket, new string[]{"["}},
            {KeyCode.Backslash, new string[]{"\\"}},
            {KeyCode.RightBracket, new string[]{"]"}},
            {KeyCode.Caret, new string[]{"^"}},
            {KeyCode.Underscore, new string[]{"_"}},
            {KeyCode.BackQuote, new string[]{"`"}},
            {KeyCode.A, new string[]{"a"}},
            {KeyCode.B, new string[]{"b"}},
            {KeyCode.C, new string[]{"c"}},
            {KeyCode.D, new string[]{"d"}},
            {KeyCode.E, new string[]{"e"}},
            {KeyCode.F, new string[]{"f"}},
            {KeyCode.G, new string[]{"g"}},
            {KeyCode.H, new string[]{"h"}},
            {KeyCode.I, new string[]{"i"}},
            {KeyCode.J, new string[]{"j"}},
            {KeyCode.K, new string[]{"k"}},
            {KeyCode.L, new string[]{"l"}},
            {KeyCode.M, new string[]{"m"}},
            {KeyCode.N, new string[]{"n"}},
            {KeyCode.O, new string[]{"o"}},
            {KeyCode.P, new string[]{"p"}},
            {KeyCode.Q, new string[]{"q"}},
            {KeyCode.R, new string[]{"r"}},
            {KeyCode.S, new string[]{"s"}},
            {KeyCode.T, new string[]{"t"}},
            {KeyCode.U, new string[]{"u"}},
            {KeyCode.V, new string[]{"v"}},
            {KeyCode.W, new string[]{"w"}},
            {KeyCode.X, new string[]{"x"}},
            {KeyCode.Y, new string[]{"y"}},
            {KeyCode.Z, new string[]{"z"}},
            {KeyCode.Numlock, new string[]{"numlock"}},
            {KeyCode.CapsLock, new string[]{"capslock"}},
            {KeyCode.ScrollLock, new string[]{"scroll lock"}},
            {KeyCode.RightShift, new string[]{"right shift"}},
            {KeyCode.LeftShift, new string[]{"left shift"}},
            {KeyCode.RightControl, new string[]{"right ctrl"}},
            {KeyCode.LeftControl, new string[]{"left ctrl"}},
            {KeyCode.RightAlt, new string[]{"right alt"}},
            {KeyCode.LeftAlt, new string[]{"left alt"}},
            {KeyCode.LeftCommand, new string[]{"left cmd"}},
            //{KeyCode.LeftApple, new string[]{"left cmd"}},
            {KeyCode.LeftWindows, new string[]{"left windows key"}},
            {KeyCode.RightCommand, new string[]{"right cmd"}},
            //{KeyCode.RightApple, new string[]{"right cmd"}},
            {KeyCode.RightWindows, new string[]{"right windows key"}},
            {KeyCode.AltGr, new string[]{"alt gr"}},
            {KeyCode.Help, new string[]{"help"}},
            {KeyCode.Print, new string[]{"print"}},
            {KeyCode.SysReq, new string[]{"sys req"}},
            {KeyCode.Break, new string[]{"break"}},
            {KeyCode.Menu, new string[]{"menu"}},
            {KeyCode.Mouse0, new string[]{"mouse 0"}},
            {KeyCode.Mouse1, new string[]{"mouse 1"}},
            {KeyCode.Mouse2, new string[]{"mouse 2"}},
            {KeyCode.Mouse3, new string[]{"mouse 3"}},
            {KeyCode.Mouse4, new string[]{"mouse 4"}},
            {KeyCode.Mouse5, new string[]{"mouse 5"}},
            {KeyCode.Mouse6, new string[]{"mouse 6"}},
            {KeyCode.JoystickButton0, new string[]{"joystick button 0"}},
            {KeyCode.JoystickButton1, new string[]{"joystick button 1"}},
            {KeyCode.JoystickButton2, new string[]{"joystick button 2"}},
            {KeyCode.JoystickButton3, new string[]{"joystick button 3"}},
            {KeyCode.JoystickButton4, new string[]{"joystick button 4"}},
            {KeyCode.JoystickButton5, new string[]{"joystick button 5"}},
            {KeyCode.JoystickButton6, new string[]{"joystick button 6"}},
            {KeyCode.JoystickButton7, new string[]{"joystick button 7"}},
            {KeyCode.JoystickButton8, new string[]{"joystick button 8"}},
            {KeyCode.JoystickButton9, new string[]{"joystick button 9"}},
            {KeyCode.JoystickButton10, new string[]{"joystick button 10"}},
            {KeyCode.JoystickButton11, new string[]{"joystick button 11"}},
            {KeyCode.JoystickButton12, new string[]{"joystick button 12"}},
            {KeyCode.JoystickButton13, new string[]{"joystick button 13"}},
            {KeyCode.JoystickButton14, new string[]{"joystick button 14"}},
            {KeyCode.JoystickButton15, new string[]{"joystick button 15"}},
            {KeyCode.JoystickButton16, new string[]{"joystick button 16"}},
            {KeyCode.JoystickButton17, new string[]{"joystick button 17"}},
            {KeyCode.JoystickButton18, new string[]{"joystick button 18"}},
            {KeyCode.JoystickButton19, new string[]{"joystick button 19"}},
            {KeyCode.Joystick1Button0, new string[]{"joystick 1 button 0"}},
            {KeyCode.Joystick1Button1, new string[]{"joystick 1 button 1"}},
            {KeyCode.Joystick1Button2, new string[]{"joystick 1 button 2"}},
            {KeyCode.Joystick1Button3, new string[]{"joystick 1 button 3"}},
            {KeyCode.Joystick1Button4, new string[]{"joystick 1 button 4"}},
            {KeyCode.Joystick1Button5, new string[]{"joystick 1 button 5"}},
            {KeyCode.Joystick1Button6, new string[]{"joystick 1 button 6"}},
            {KeyCode.Joystick1Button7, new string[]{"joystick 1 button 7"}},
            {KeyCode.Joystick1Button8, new string[]{"joystick 1 button 8"}},
            {KeyCode.Joystick1Button9, new string[]{"joystick 1 button 9"}},
            {KeyCode.Joystick1Button10, new string[]{"joystick 1 button 10"}},
            {KeyCode.Joystick1Button11, new string[]{"joystick 1 button 11"}},
            {KeyCode.Joystick1Button12, new string[]{"joystick 1 button 12"}},
            {KeyCode.Joystick1Button13, new string[]{"joystick 1 button 13"}},
            {KeyCode.Joystick1Button14, new string[]{"joystick 1 button 14"}},
            {KeyCode.Joystick1Button15, new string[]{"joystick 1 button 15"}},
            {KeyCode.Joystick1Button16, new string[]{"joystick 1 button 16"}},
            {KeyCode.Joystick1Button17, new string[]{"joystick 1 button 17"}},
            {KeyCode.Joystick1Button18, new string[]{"joystick 1 button 18"}},
            {KeyCode.Joystick1Button19, new string[]{"joystick 1 button 19"}},
            {KeyCode.Joystick2Button0, new string[]{"joystick 2 button 0"}},
            {KeyCode.Joystick2Button1, new string[]{"joystick 2 button 1"}},
            {KeyCode.Joystick2Button2, new string[]{"joystick 2 button 2"}},
            {KeyCode.Joystick2Button3, new string[]{"joystick 2 button 3"}},
            {KeyCode.Joystick2Button4, new string[]{"joystick 2 button 4"}},
            {KeyCode.Joystick2Button5, new string[]{"joystick 2 button 5"}},
            {KeyCode.Joystick2Button6, new string[]{"joystick 2 button 6"}},
            {KeyCode.Joystick2Button7, new string[]{"joystick 2 button 7"}},
            {KeyCode.Joystick2Button8, new string[]{"joystick 2 button 8"}},
            {KeyCode.Joystick2Button9, new string[]{"joystick 2 button 9"}},
            {KeyCode.Joystick2Button10, new string[]{"joystick 2 button 10"}},
            {KeyCode.Joystick2Button11, new string[]{"joystick 2 button 11"}},
            {KeyCode.Joystick2Button12, new string[]{"joystick 2 button 12"}},
            {KeyCode.Joystick2Button13, new string[]{"joystick 2 button 13"}},
            {KeyCode.Joystick2Button14, new string[]{"joystick 2 button 14"}},
            {KeyCode.Joystick2Button15, new string[]{"joystick 2 button 15"}},
            {KeyCode.Joystick2Button16, new string[]{"joystick 2 button 16"}},
            {KeyCode.Joystick2Button17, new string[]{"joystick 2 button 17"}},
            {KeyCode.Joystick2Button18, new string[]{"joystick 2 button 18"}},
            {KeyCode.Joystick2Button19, new string[]{"joystick 2 button 19"}},
            {KeyCode.Joystick3Button0, new string[]{"joystick 3 button 0"}},
            {KeyCode.Joystick3Button1, new string[]{"joystick 3 button 1"}},
            {KeyCode.Joystick3Button2, new string[]{"joystick 3 button 2"}},
            {KeyCode.Joystick3Button3, new string[]{"joystick 3 button 3"}},
            {KeyCode.Joystick3Button4, new string[]{"joystick 3 button 4"}},
            {KeyCode.Joystick3Button5, new string[]{"joystick 3 button 5"}},
            {KeyCode.Joystick3Button6, new string[]{"joystick 3 button 6"}},
            {KeyCode.Joystick3Button7, new string[]{"joystick 3 button 7"}},
            {KeyCode.Joystick3Button8, new string[]{"joystick 3 button 8"}},
            {KeyCode.Joystick3Button9, new string[]{"joystick 3 button 9"}},
            {KeyCode.Joystick3Button10, new string[]{"joystick 3 button 10"}},
            {KeyCode.Joystick3Button11, new string[]{"joystick 3 button 11"}},
            {KeyCode.Joystick3Button12, new string[]{"joystick 3 button 12"}},
            {KeyCode.Joystick3Button13, new string[]{"joystick 3 button 13"}},
            {KeyCode.Joystick3Button14, new string[]{"joystick 3 button 14"}},
            {KeyCode.Joystick3Button15, new string[]{"joystick 3 button 15"}},
            {KeyCode.Joystick3Button16, new string[]{"joystick 3 button 16"}},
            {KeyCode.Joystick3Button17, new string[]{"joystick 3 button 17"}},
            {KeyCode.Joystick3Button18, new string[]{"joystick 3 button 18"}},
            {KeyCode.Joystick3Button19, new string[]{"joystick 3 button 19"}},
            {KeyCode.Joystick4Button0, new string[]{"joystick 4 button 0"}},
            {KeyCode.Joystick4Button1, new string[]{"joystick 4 button 1"}},
            {KeyCode.Joystick4Button2, new string[]{"joystick 4 button 2"}},
            {KeyCode.Joystick4Button3, new string[]{"joystick 4 button 3"}},
            {KeyCode.Joystick4Button4, new string[]{"joystick 4 button 4"}},
            {KeyCode.Joystick4Button5, new string[]{"joystick 4 button 5"}},
            {KeyCode.Joystick4Button6, new string[]{"joystick 4 button 6"}},
            {KeyCode.Joystick4Button7, new string[]{"joystick 4 button 7"}},
            {KeyCode.Joystick4Button8, new string[]{"joystick 4 button 8"}},
            {KeyCode.Joystick4Button9, new string[]{"joystick 4 button 9"}},
            {KeyCode.Joystick4Button10, new string[]{"joystick 4 button 10"}},
            {KeyCode.Joystick4Button11, new string[]{"joystick 4 button 11"}},
            {KeyCode.Joystick4Button12, new string[]{"joystick 4 button 12"}},
            {KeyCode.Joystick4Button13, new string[]{"joystick 4 button 13"}},
            {KeyCode.Joystick4Button14, new string[]{"joystick 4 button 14"}},
            {KeyCode.Joystick4Button15, new string[]{"joystick 4 button 15"}},
            {KeyCode.Joystick4Button16, new string[]{"joystick 4 button 16"}},
            {KeyCode.Joystick4Button17, new string[]{"joystick 4 button 17"}},
            {KeyCode.Joystick4Button18, new string[]{"joystick 4 button 18"}},
            {KeyCode.Joystick4Button19, new string[]{"joystick 4 button 19"}},
            {KeyCode.Joystick5Button0, new string[]{"joystick 5 button 0"}},
            {KeyCode.Joystick5Button1, new string[]{"joystick 5 button 1"}},
            {KeyCode.Joystick5Button2, new string[]{"joystick 5 button 2"}},
            {KeyCode.Joystick5Button3, new string[]{"joystick 5 button 3"}},
            {KeyCode.Joystick5Button4, new string[]{"joystick 5 button 4"}},
            {KeyCode.Joystick5Button5, new string[]{"joystick 5 button 5"}},
            {KeyCode.Joystick5Button6, new string[]{"joystick 5 button 6"}},
            {KeyCode.Joystick5Button7, new string[]{"joystick 5 button 7"}},
            {KeyCode.Joystick5Button8, new string[]{"joystick 5 button 8"}},
            {KeyCode.Joystick5Button9, new string[]{"joystick 5 button 9"}},
            {KeyCode.Joystick5Button10, new string[]{"joystick 5 button 10"}},
            {KeyCode.Joystick5Button11, new string[]{"joystick 5 button 11"}},
            {KeyCode.Joystick5Button12, new string[]{"joystick 5 button 12"}},
            {KeyCode.Joystick5Button13, new string[]{"joystick 5 button 13"}},
            {KeyCode.Joystick5Button14, new string[]{"joystick 5 button 14"}},
            {KeyCode.Joystick5Button15, new string[]{"joystick 5 button 15"}},
            {KeyCode.Joystick5Button16, new string[]{"joystick 5 button 16"}},
            {KeyCode.Joystick5Button17, new string[]{"joystick 5 button 17"}},
            {KeyCode.Joystick5Button18, new string[]{"joystick 5 button 18"}},
            {KeyCode.Joystick5Button19, new string[]{"joystick 5 button 19"}},
            {KeyCode.Joystick6Button0, new string[]{"joystick 6 button 0"}},
            {KeyCode.Joystick6Button1, new string[]{"joystick 6 button 1"}},
            {KeyCode.Joystick6Button2, new string[]{"joystick 6 button 2"}},
            {KeyCode.Joystick6Button3, new string[]{"joystick 6 button 3"}},
            {KeyCode.Joystick6Button4, new string[]{"joystick 6 button 4"}},
            {KeyCode.Joystick6Button5, new string[]{"joystick 6 button 5"}},
            {KeyCode.Joystick6Button6, new string[]{"joystick 6 button 6"}},
            {KeyCode.Joystick6Button7, new string[]{"joystick 6 button 7"}},
            {KeyCode.Joystick6Button8, new string[]{"joystick 6 button 8"}},
            {KeyCode.Joystick6Button9, new string[]{"joystick 6 button 9"}},
            {KeyCode.Joystick6Button10, new string[]{"joystick 6 button 10"}},
            {KeyCode.Joystick6Button11, new string[]{"joystick 6 button 11"}},
            {KeyCode.Joystick6Button12, new string[]{"joystick 6 button 12"}},
            {KeyCode.Joystick6Button13, new string[]{"joystick 6 button 13"}},
            {KeyCode.Joystick6Button14, new string[]{"joystick 6 button 14"}},
            {KeyCode.Joystick6Button15, new string[]{"joystick 6 button 15"}},
            {KeyCode.Joystick6Button16, new string[]{"joystick 6 button 16"}},
            {KeyCode.Joystick6Button17, new string[]{"joystick 6 button 17"}},
            {KeyCode.Joystick6Button18, new string[]{"joystick 6 button 18"}},
            {KeyCode.Joystick6Button19, new string[]{"joystick 6 button 19"}},
            {KeyCode.Joystick7Button0, new string[]{"joystick 7 button 0"}},
            {KeyCode.Joystick7Button1, new string[]{"joystick 7 button 1"}},
            {KeyCode.Joystick7Button2, new string[]{"joystick 7 button 2"}},
            {KeyCode.Joystick7Button3, new string[]{"joystick 7 button 3"}},
            {KeyCode.Joystick7Button4, new string[]{"joystick 7 button 4"}},
            {KeyCode.Joystick7Button5, new string[]{"joystick 7 button 5"}},
            {KeyCode.Joystick7Button6, new string[]{"joystick 7 button 6"}},
            {KeyCode.Joystick7Button7, new string[]{"joystick 7 button 7"}},
            {KeyCode.Joystick7Button8, new string[]{"joystick 7 button 8"}},
            {KeyCode.Joystick7Button9, new string[]{"joystick 7 button 9"}},
            {KeyCode.Joystick7Button10, new string[]{"joystick 7 button 10"}},
            {KeyCode.Joystick7Button11, new string[]{"joystick 7 button 11"}},
            {KeyCode.Joystick7Button12, new string[]{"joystick 7 button 12"}},
            {KeyCode.Joystick7Button13, new string[]{"joystick 7 button 13"}},
            {KeyCode.Joystick7Button14, new string[]{"joystick 7 button 14"}},
            {KeyCode.Joystick7Button15, new string[]{"joystick 7 button 15"}},
            {KeyCode.Joystick7Button16, new string[]{"joystick 7 button 16"}},
            {KeyCode.Joystick7Button17, new string[]{"joystick 7 button 17"}},
            {KeyCode.Joystick7Button18, new string[]{"joystick 7 button 18"}},
            {KeyCode.Joystick7Button19, new string[]{"joystick 7 button 19"}},
            {KeyCode.Joystick8Button0, new string[]{"joystick 8 button 0"}},
            {KeyCode.Joystick8Button1, new string[]{"joystick 8 button 1"}},
            {KeyCode.Joystick8Button2, new string[]{"joystick 8 button 2"}},
            {KeyCode.Joystick8Button3, new string[]{"joystick 8 button 3"}},
            {KeyCode.Joystick8Button4, new string[]{"joystick 8 button 4"}},
            {KeyCode.Joystick8Button5, new string[]{"joystick 8 button 5"}},
            {KeyCode.Joystick8Button6, new string[]{"joystick 8 button 6"}},
            {KeyCode.Joystick8Button7, new string[]{"joystick 8 button 7"}},
            {KeyCode.Joystick8Button8, new string[]{"joystick 8 button 8"}},
            {KeyCode.Joystick8Button9, new string[]{"joystick 8 button 9"}},
            {KeyCode.Joystick8Button10, new string[]{"joystick 8 button 10"}},
            {KeyCode.Joystick8Button11, new string[]{"joystick 8 button 11"}},
            {KeyCode.Joystick8Button12, new string[]{"joystick 8 button 12"}},
            {KeyCode.Joystick8Button13, new string[]{"joystick 8 button 13"}},
            {KeyCode.Joystick8Button14, new string[]{"joystick 8 button 14"}},
            {KeyCode.Joystick8Button15, new string[]{"joystick 8 button 15"}},
            {KeyCode.Joystick8Button16, new string[]{"joystick 8 button 16"}},
            {KeyCode.Joystick8Button17, new string[]{"joystick 8 button 17"}},
            {KeyCode.Joystick8Button18, new string[]{"joystick 8 button 18"}},
            {KeyCode.Joystick8Button19, new string[]{"joystick 8 button 19"}}
        };

        /// <summary>
        /// 指定キーコードをinput文字列に変換する
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="keyCode">Key code.</param>
        public static string ConvertKeyCodeToInputString(KeyCode keyCode)
        {
            if (KeyCodeConvertDict.ContainsKey(keyCode))
            {
                return KeyCodeConvertDict[keyCode][0];
            }
            Debug.Log("対応したキーがありません : " + keyCode);
            return KeyCodeConvertDict[KeyCode.None][0];
        }

        public static string ConvertIntToInputString(int keyCode)
        {
            if (KeyCodeConvertDict.ContainsKey((KeyCode)keyCode))
            {
                return KeyCodeConvertDict[(KeyCode)keyCode][0];
            }
            Debug.Log("対応したキーがありません : " + keyCode);
            return KeyCodeConvertDict[KeyCode.None][0];
        }

        /// <summary>
        /// 指定文字列がKeyCodeに変換する
        /// なければNone
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static KeyCode ConvertInputStringToKeyCode(string inputString)
        {
            foreach(var keycodeStringPair in KeyCodeConvertDict)
            {
                foreach (var name in keycodeStringPair.Value)
                {
                    if (name == inputString)
                    {
                        return keycodeStringPair.Key;
                    }
                }
            }
            Debug.Log("変換できるKeyCodeがありませんでした : " + inputString);
            return KeyCode.None;
        }
        
        /// <summary>
        /// 指定文字列がKeyCodeに変換する
        /// なければNone
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static int ConvertInputStringToIntKeyCode(string inputString)
        {
            foreach(var keycodeStringPair in KeyCodeConvertDict)
            {
                foreach (var name in keycodeStringPair.Value)
                {
                    if (name == inputString)
                    {
                        return (int)keycodeStringPair.Key;
                    }
                }
            }
            Debug.Log("変換できるKeyCodeがありませんでした : " + inputString);
            return (int)KeyCode.None;
        }
    }
}
