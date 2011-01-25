﻿//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2011 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.IO;
using Ict.Common.Printing;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Ict.Common.Printing
{
    /// <summary>
    /// this printer uses PdfSharp to print to PDF.
    /// we need to overwrite the graphics functions, otherwise we use the same layout/text wrapping functions like TGfxPrinter
    /// </summary>
    public class TPdfPrinter : TGfxPrinter
    {
        private XGraphics FXGraphics;

        /// todoComment
        public XFont FXDefaultFont;

        /// todoComment
        public XFont FXDefaultBoldFont;

        /// todoComment
        public XFont FXHeadingFont;

        /// todoComment
        public XFont FXSmallPrintFont;

        /// todoComment
        public XFont FXBiggestLastUsedFont;
        private XStringFormat FXLeft;
        private XStringFormat FXRight;
        private XStringFormat FXCenter;
        private XPen FXBlackPen;

        /// <summary>
        /// constructor
        /// </summary>
        public TPdfPrinter(System.Drawing.Printing.PrintDocument ADocument, ePrinterBehaviour APrinterBehaviour) : base(ADocument, APrinterBehaviour)
        {
        }

        /// the fonts need to be a little bit bigger so that they have the same size as the GfxPrinter?
        private const int XFONTSIZE = 3;

        /// <summary>
        /// initialise the fonts and pens.
        /// this can only happen when the Graphics and GraphicsUnit are known.
        /// </summary>
        private void InitFontsAndPens()
        {
            FXBlackPen = new XPen(XColor.FromKnownColor(XKnownColor.Black), Cm(0.05f));

            // the fonts need to be a little bit bigger so that they have the same size as the GfxPrinter?
            FXSmallPrintFont = new XFont("Arial", 0.12); // Point(6 + XFONTSIZE)
            FXDefaultFont = new XFont("Arial", 0.14); // Point(8 + XFONTSIZE)
            FXDefaultBoldFont = new XFont("Arial", 0.14, XFontStyle.Bold); // Point(8 + XFONTSIZE)
            FXHeadingFont = new XFont("Arial", 0.16, XFontStyle.Bold); // Point(10 + XFONTSIZE)
            FXBiggestLastUsedFont = FXDefaultFont;
            FXRight = new XStringFormat();
            FXRight.Alignment = XStringAlignment.Far;
            FXLeft = new XStringFormat();
            FXLeft.Alignment = XStringAlignment.Near;
            FXCenter = new XStringFormat();
            FXCenter.Alignment = XStringAlignment.Center;
        }

        private XFont GetXFont(eFont AFont)
        {
            XFont ReturnValue;

            ReturnValue = FXDefaultFont;

            switch (AFont)
            {
                case eFont.eDefaultFont:
                    ReturnValue = FXDefaultFont;
                    break;

                case eFont.eDefaultBoldFont:
                    ReturnValue = FXDefaultBoldFont;
                    break;

                case eFont.eHeadingFont:
                    ReturnValue = FXHeadingFont;
                    break;

                case eFont.eSmallPrintFont:
                    ReturnValue = FXSmallPrintFont;
                    break;
            }

            if (CurrentRelativeFontSize != 0)
            {
                // TODO it seems negative values have no effect?
                Font gFont = GetFont(AFont);
                ReturnValue = new XFont(gFont.FontFamily, Point(gFont.SizeInPoints /*+XFONTSIZE*/), ReturnValue.Style, null);
            }

            return ReturnValue;
        }

        /// <summary>
        /// update the biggest last used font for the next line feed
        /// </summary>
        /// <param name="AFont"></param>
        protected override bool UpdateBiggestLastUsedFont(eFont AFont)
        {
            if (base.UpdateBiggestLastUsedFont(AFont))
            {
                FXBiggestLastUsedFont = GetXFont(AFont);
                return true;
            }

            return false;
        }

        private XStringFormat GetXStringFormat(eAlignment AAlign)
        {
            XStringFormat ReturnValue;

            ReturnValue = FXLeft;

            switch (AAlign)
            {
                case eAlignment.eDefault:
                    ReturnValue = FXLeft;
                    break;

                case eAlignment.eLeft:
                    ReturnValue = FXLeft;
                    break;

                case eAlignment.eRight:
                    ReturnValue = FXRight;
                    break;

                case eAlignment.eCenter:
                    ReturnValue = FXCenter;
                    break;
            }

            return ReturnValue;
        }

        /// <summary>
        /// prints into the current line, aligned x position
        ///
        /// </summary>
        public override Boolean PrintString(String ATxt, eFont AFont, eAlignment AAlign)
        {
            RectangleF rect;

            rect = new RectangleF(FLeftMargin, CurrentYPos, FWidth, (float)GetXFont(AFont).GetHeight(FXGraphics));

            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                ATxt = GetFittedText(ATxt, AFont, rect.Width);
                FXGraphics.DrawString(ATxt, GetXFont(AFont), Brushes.Black, rect, GetXStringFormat(AAlign));
            }

            return (ATxt != null) && (ATxt.Length != 0);
        }

        /// <summary>
        /// prints into the current line, absolute x position
        ///
        /// </summary>
        public override Boolean PrintString(String ATxt, eFont AFont, float AXPos)
        {
            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                FXGraphics.DrawString(ATxt, GetXFont(AFont), Brushes.Black, AXPos, CurrentYPos);
            }

            return (ATxt != null) && (ATxt.Length != 0);
        }

        /// <summary>
        /// prints into the current line, absolute x position with width and alignment
        /// </summary>
        /// <returns>true if something was printed</returns>
        public override Boolean PrintString(String ATxt, eFont AFont, float AXPos, float AWidth, eAlignment AAlign)
        {
            RectangleF rect = new RectangleF(AXPos, CurrentYPos, AWidth, (float)GetXFont(AFont).GetHeight(FXGraphics));

            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                XStringFormat f = GetXStringFormat(AAlign);
                f.FormatFlags = XStringFormatFlags.MeasureTrailingSpaces;

                if (FPrinterBehaviour == ePrinterBehaviour.eReport)
                {
                    ATxt = GetFittedText(ATxt, AFont, rect.Width);
                }

                //TLogging.Log("curr ypos " + CurrentYPos.ToString() + " " + AXPos.ToString() + " " + ATxt + AWidth.ToString());
                FXGraphics.DrawString(ATxt, GetXFont(AFont), Brushes.Black, rect, f);
            }

            return (ATxt != null) && (ATxt.Length != 0);
        }

        /// <summary>
        /// Draws a line, either above or below the current text line
        /// the font is required to get the height of the row
        /// </summary>
        /// <param name="AXPos1"></param>
        /// <param name="AXPos2"></param>
        /// <param name="ALinePosition"></param>
        /// <param name="AFont"></param>
        /// <returns></returns>
        public override Boolean DrawLine(float AXPos1, float AXPos2, eLinePosition ALinePosition, eFont AFont)
        {
            float YPos;

            YPos = CurrentYPos;

            if (ALinePosition == eLinePosition.eBelow)
            {
                YPos = CurrentYPos + (float)GetXFont(AFont).GetHeight(FXGraphics);
            }
            else if (ALinePosition == eLinePosition.eAbove)
            {
                YPos = CurrentYPos;
            }

            if (AXPos1 != LeftMargin)
            {
                // lines above/below columns should not touch
                AXPos1 = AXPos1 + Cm(0.3f);
            }

            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                FXGraphics.DrawLine(FXBlackPen, AXPos1, YPos, AXPos2, YPos);
            }

            return true;
        }

        /// <summary>
        /// draw a rectangle
        /// </summary>
        /// <param name="APenPixels"></param>
        /// <param name="AXPos"></param>
        /// <param name="AYPos"></param>
        /// <param name="AWidth"></param>
        /// <param name="AHeight"></param>
        public override void DrawRectangle(Int32 APenPixels,
            float AXPos,
            float AYPos,
            float AWidth,
            float AHeight)
        {
            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                FXGraphics.DrawRectangle(FXBlackPen, AXPos, AYPos, AWidth, AHeight);
            }
        }

        /// <summary>
        /// draw a bitmap at the given position;
        /// the current position is moved
        /// </summary>
        /// <param name="APath"></param>
        /// <param name="AXPos"></param>
        /// <param name="AYPos"></param>
        public override void DrawBitmap(string APath,
            float AXPos,
            float AYPos)
        {
            if (!File.Exists(APath))
            {
                TLogging.Log("cannot draw bitmap because file does not exist " + APath);
                return;
            }

            Bitmap img = new System.Drawing.Bitmap(APath);

            if ((img != null) && (PrintingMode == ePrintingMode.eDoPrint))
            {
                FXGraphics.DrawImage(img, AXPos, AYPos);
            }

            // FEv.Graphics.PageUnit is inch; therefore need to convert pixel to inch
            // pixel/inch = dpi <=> inch = pixel/dpi
            CurrentYPos += img.Size.Height / img.VerticalResolution;
            CurrentXPos += img.Size.Width / img.HorizontalResolution;
        }

        float Pixel2Twips(float APixelNumber)
        {
            return APixelNumber / 100.0f;
        }

        /// <summary>
        /// draw a bitmap at the given position;
        /// the current position is moved
        ///
        /// Either Width or WidthPercentage should be unequals 0, but only one should have a value.
        /// Same applies to Height
        /// </summary>
        public override void DrawBitmap(string APath,
            float AXPos,
            float AYPos,
            float AWidth,
            float AHeight,
            float AWidthPercentage,
            float AHeightPercentage)
        {
            if (!System.IO.File.Exists(APath))
            {
                throw new Exception("TGfxPrinter.DrawBitmap: cannot find image file " + APath);
            }

            Bitmap img = new System.Drawing.Bitmap(APath);
            float Height = img.Size.Height;

            if (AHeightPercentage != 0.0f)
            {
                Height = Height / img.VerticalResolution * AHeightPercentage;
            }
            else
            {
                Height = Pixel2Twips(AHeight);
            }

            float Width = img.Size.Width;

            if (AHeightPercentage != 0.0f)
            {
                Width = Width / img.HorizontalResolution * AWidthPercentage;
            }
            else
            {
                Width = Pixel2Twips(AWidth);
            }

            if (PrintingMode == ePrintingMode.eDoPrint)
            {
                FXGraphics.DrawImage(img, AXPos, AYPos, Width, Height);
            }

            // FEv.Graphics.PageUnit is inch; therefore need to convert pixel to inch
            // pixel/inch = dpi <=> inch = pixel/dpi
            CurrentYPos += Height;
            CurrentXPos += Width;
        }

        private float GetFontHeight(eFont AFont)
        {
            return GetFontHeight(GetXFont(AFont));
        }

        private float GetFontHeight(XFont AFont)
        {
            return (float)Math.Round(AFont.Size, 2);     //  .GetHeight(FXGraphics)
        }

        /// <summary>
        /// Line Feed; increases the current y position by the height of the biggest last used font
        /// </summary>
        /// <returns>the new current line</returns>
        public override float LineFeed()
        {
            CurrentYPos += GetFontHeight(FXBiggestLastUsedFont);

            // reset the biggest last used font
            FXBiggestLastUsedFont = FXDefaultFont;
            FBiggestLastUsedFont = FDefaultFont;
            return CurrentYPos;
        }

        /// <summary>
        /// Line Feed, but not full line; increases the current y position by half the height of the given font
        /// </summary>
        /// <returns>the new current line
        /// </returns>
        public override float LineSpaceFeed(eFont AFont)
        {
            CurrentYPos = CurrentYPos + GetFontHeight(AFont) / 2;
            return CurrentYPos;
        }

        /// <summary>
        /// Reverse Line Feed; decreases the current y position by the height of the given font
        /// </summary>
        /// <returns>the new current line
        /// </returns>
        public override float LineUnFeed(eFont AFont)
        {
            CurrentYPos = CurrentYPos - GetFontHeight(AFont);
            return CurrentYPos;
        }

        /// <summary>
        /// print the page, either to PDF or to the screen
        /// </summary>
        /// <param name="ASender"></param>
        /// <param name="AEv"></param>
        protected override void PrintPage(object ASender, PrintPageEventArgs AEv)
        {
            // only use the AEv.Graphics if we display on screen
            if (FEv != AEv)
            {
                FEv = AEv;
                FEv.Graphics.PageUnit = GraphicsUnit.Inch;
                FEv.Graphics.TranslateTransform(0, 0);
                FXGraphics = XGraphics.FromGraphics(AEv.Graphics, PageSizeConverter.ToSize(PageSize.A4));
                InitFontsAndPens();
            }

            base.PrintPage(ASender, AEv);
        }

        /// <summary>
        /// store a pdf to a file. will call PrintPage automatically
        /// </summary>
        /// <param name="AFilename"></param>
        public void SavePDF(string AFilename)
        {
            if (Directory.Exists("/usr/share/fonts/"))
            {
                PdfSharp.Internal.NativeMethods.FontDirectory = "/usr/share/fonts/";
            }

            if (RegionInfo.CurrentRegion == null)
            {
                // https://bugzilla.novell.com/show_bug.cgi?id=588708
                // RegionInfo.CurrentRegion is null
                throw new Exception("Mono bug: CurrentRegion is still null, invariant culture. Please set LANG environment variable");
            }

            PdfDocument pdfDocument = new PdfDocument();

            do
            {
                PdfPage page = pdfDocument.AddPage();
                page.Size = PageSize.A4;
                FXGraphics = XGraphics.FromPdfPage(page, XGraphicsUnit.Inch);

                if (FEv == null)
                {
                    PrinterSettings myPrinterSettings = new PrinterSettings();
                    PageSettings myPageSettings = new PageSettings(myPrinterSettings);
                    myPageSettings.Color = true;
                    myPageSettings.Landscape = false;
                    myPageSettings.Margins = new Margins(20, 20, 20, 39);
                    myPageSettings.PaperSize = new PaperSize("A4", 900, 827);
                    try
                    {
                        myPageSettings.PrinterResolution.X = 600;
                        myPageSettings.PrinterResolution.Y = 600;
                    }
                    catch (Exception)
                    {
                        // if no printer is installed we get an exception, but it should work anyway
                    }
                    FEv = new PrintPageEventArgs(FXGraphics.Graphics,
                        new Rectangle(20, 20, 787, 1110),
                        new Rectangle(0, 0, 827, 1169),
                        myPageSettings);
                    FEv.HasMorePages = true;
                    FEv.Graphics.PageUnit = GraphicsUnit.Inch;
                    FEv.Graphics.TranslateTransform(0, 0);
                    InitFontsAndPens();
                }

                PrintPage(null, FEv);
            } while (HasMorePages());

            // should we catch an exception if document cannot be written?
            pdfDocument.Save(AFilename);
            pdfDocument.Close();
        }
    }
}