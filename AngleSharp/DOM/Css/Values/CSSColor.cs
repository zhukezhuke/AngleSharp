﻿namespace AngleSharp.DOM.Css
{
    using System;

    sealed class CSSColor : CSSValue
    {
        #region Fields

        Color _value;

        #endregion

        #region ctor

        public CSSColor(Color value)
        {
            _type = CssValueType.PrimitiveValue;
            _text = value.ToString();
            _value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value of the CSS color.
        /// </summary>
        public Color Color
        {
            get { return _value; }
        }

        /// <summary>
        /// Gets the unit type of the value.
        /// </summary>
        public CssUnit PrimitiveType
        {
            get { return CssUnit.Rgbcolor; }
        }

        #endregion
    }
}
