﻿namespace AngleSharp.DOM.Css
{
    using System;
    using System.Collections.Generic;

    abstract class CSSFunction : CSSValue
    {
        protected List<CSSValue> _args;

		internal CSSFunction()
        {
        }

        internal static CSSValue Create(String name, List<CSSValue> arguments)
        {
            if (name == FunctionNames.Rgb && arguments.Count == 3)
            {
                if (CheckNumber(arguments[0]) && CheckNumber(arguments[1]) && CheckNumber(arguments[2]))
                    return new CSSColor(Color.FromRgb(ToByte(arguments[0]), ToByte(arguments[1]), ToByte(arguments[2])));
            }
            else if (name == FunctionNames.Rgba && arguments.Count == 4)
            {
                if (CheckNumber(arguments[0]) && CheckNumber(arguments[1]) && CheckNumber(arguments[2]) && CheckNumber(arguments[3]))
                    return new CSSColor(Color.FromRgba(ToByte(arguments[0]), ToByte(arguments[1]), ToByte(arguments[2]), ToSingle(arguments[3])));
            }
            else if (name == FunctionNames.Hsl && arguments.Count == 3)
            {
                if (CheckNumber(arguments[0]) && CheckNumber(arguments[1]) && CheckNumber(arguments[2]))
                    return new CSSColor(Color.FromHsl(ToSingle(arguments[0]), ToSingle(arguments[1]), ToSingle(arguments[2])));
            }

            return new CSSUnknownFunction(name) { _args = arguments };
        }

        #region Helpers

        static Boolean CheckNumber(CSSValue cssValue)
        {
            return cssValue is CSSNumber;
        }

        static Single ToSingle(CSSValue cssValue)
        {
            return ((CSSNumber)cssValue).Value;
        }

        static Byte ToByte(CSSValue cssValue)
        {
            return (Byte)Math.Min(Math.Max(((CSSNumber)cssValue).Value, 0), 255);
        }

        #endregion

        class CSSUnknownFunction : CSSFunction
        {
            public CSSUnknownFunction(String name)
            {
                _text = name;
            }

            public override String ToCss()
            {
                var sb = Pool.NewStringBuilder().Append(_text);
                sb.Append(Specification.RBO);

                for (int i = 0; i < _args.Count; i++)
                {
                    sb.Append(_args[i].ToCss());

                    if (i != _args.Count - 1)
                        sb.Append(Specification.COMMA).Append(Specification.SPACE);
                }
                
                sb.Append(Specification.RBC);
                return sb.ToPool();
            }
        }

        class CSSCalcFunction : CSSFunction
        {

        }

        class CSSAttrFunction : CSSFunction
        {

        }

        class CSSToggleFunction : CSSFunction
        {

        }

        class CSSRotateFunction : CSSFunction
        {

        }

        class CSSTransformFunction : CSSFunction
        {

        }

        class CSSSkewFunction : CSSFunction
        {

        }

        class CSSLinearGradientFunction : CSSFunction
        {

        }
    }
}
