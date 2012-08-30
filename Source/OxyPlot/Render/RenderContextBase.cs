// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenderContextBase.cs" company="OxyPlot">
//   http://oxyplot.codeplex.com, license: Ms-PL
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot
{
    using System.Collections.Generic;

    /// <summary>
    /// The abstract render context base class.
    /// </summary>
    public abstract class RenderContextBase : IRenderContext
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the height of the rendering area.
        /// </summary>
        public double Height { get; protected set; }

        /// <summary>
        ///   Gets or sets a value indicating whether to paint the background.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the background should be painted; otherwise, <c>false</c>.
        /// </value>
        public bool PaintBackground { get; protected set; }

        /// <summary>
        ///   Gets or sets the width of the rendering area.
        /// </summary>
        public double Width { get; protected set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Draws an ellipse.
        /// </summary>
        /// <param name="rect">
        /// The rectangle.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The thickness.
        /// </param>
        public abstract void DrawEllipse(OxyRect rect, OxyColor fill, OxyColor stroke, double thickness);

        /// <summary>
        /// Draws the collection of ellipses, where all have the same stroke and fill.
        ///   This performs better than calling DrawEllipse multiple times.
        /// </summary>
        /// <param name="rectangles">
        /// The rectangles.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        public virtual void DrawEllipses(IList<OxyRect> rectangles, OxyColor fill, OxyColor stroke, double thickness)
        {
            foreach (var r in rectangles)
            {
                this.DrawEllipse(r, fill, stroke, thickness);
            }
        }

        /// <summary>
        /// Draws the polyline from the specified points.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        /// <param name="dashArray">
        /// The dash array.
        /// </param>
        /// <param name="lineJoin">
        /// The line join type.
        /// </param>
        /// <param name="aliased">
        /// if set to <c>true</c> the shape will be aliased.
        /// </param>
        public abstract void DrawLine(
            IList<ScreenPoint> points, 
            OxyColor stroke, 
            double thickness, 
            double[] dashArray, 
            OxyPenLineJoin lineJoin, 
            bool aliased);

        /// <summary>
        /// Draws the multiple line segments defined by points (0,1) (2,3) (4,5) etc.
        ///   This should have better performance than calling DrawLine for each segment.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        /// <param name="dashArray">
        /// The dash array.
        /// </param>
        /// <param name="lineJoin">
        /// The line join type.
        /// </param>
        /// <param name="aliased">
        /// if set to <c>true</c> the shape will be aliased.
        /// </param>
        public virtual void DrawLineSegments(
            IList<ScreenPoint> points, 
            OxyColor stroke, 
            double thickness, 
            double[] dashArray, 
            OxyPenLineJoin lineJoin, 
            bool aliased)
        {
            for (int i = 0; i + 1 < points.Count; i += 2)
            {
                this.DrawLine(new[] { points[i], points[i + 1] }, stroke, thickness, dashArray, lineJoin, aliased);
            }
        }

        /// <summary>
        /// Draws the polygon from the specified points. The polygon can have stroke and/or fill.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        /// <param name="dashArray">
        /// The dash array.
        /// </param>
        /// <param name="lineJoin">
        /// The line join type.
        /// </param>
        /// <param name="aliased">
        /// if set to <c>true</c> the shape will be aliased.
        /// </param>
        public abstract void DrawPolygon(
            IList<ScreenPoint> points, 
            OxyColor fill, 
            OxyColor stroke, 
            double thickness, 
            double[] dashArray, 
            OxyPenLineJoin lineJoin, 
            bool aliased);

        /// <summary>
        /// Draws a collection of polygons, where all polygons have the same stroke and fill.
        ///   This performs better than calling DrawPolygon multiple times.
        /// </summary>
        /// <param name="polygons">
        /// The polygons.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        /// <param name="dashArray">
        /// The dash array.
        /// </param>
        /// <param name="lineJoin">
        /// The line join type.
        /// </param>
        /// <param name="aliased">
        /// if set to <c>true</c> the shape will be aliased.
        /// </param>
        public virtual void DrawPolygons(
            IList<IList<ScreenPoint>> polygons, 
            OxyColor fill, 
            OxyColor stroke, 
            double thickness, 
            double[] dashArray, 
            OxyPenLineJoin lineJoin, 
            bool aliased)
        {
            foreach (var polygon in polygons)
            {
                this.DrawPolygon(polygon, fill, stroke, thickness, dashArray, lineJoin, aliased);
            }
        }

        /// <summary>
        /// Draws the rectangle.
        /// </summary>
        /// <param name="rect">
        /// The rectangle.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        public abstract void DrawRectangle(OxyRect rect, OxyColor fill, OxyColor stroke, double thickness);

        /// <summary>
        /// Draws a collection of rectangles, where all have the same stroke and fill.
        ///   This performs better than calling DrawRectangle multiple times.
        /// </summary>
        /// <param name="rectangles">
        /// The rectangles.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="stroke">
        /// The stroke color.
        /// </param>
        /// <param name="thickness">
        /// The stroke thickness.
        /// </param>
        public virtual void DrawRectangles(IList<OxyRect> rectangles, OxyColor fill, OxyColor stroke, double thickness)
        {
            foreach (var r in rectangles)
            {
                this.DrawRectangle(r, fill, stroke, thickness);
            }
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="fill">
        /// The fill color.
        /// </param>
        /// <param name="fontFamily">
        /// The font family.
        /// </param>
        /// <param name="fontSize">
        /// Size of the font.
        /// </param>
        /// <param name="fontWeight">
        /// The font weight.
        /// </param>
        /// <param name="rotate">
        /// The rotatation angle.
        /// </param>
        /// <param name="halign">
        /// The horizontal alignment.
        /// </param>
        /// <param name="valign">
        /// The vertical alignment.
        /// </param>
        /// <param name="maxSize">
        /// The maximum size of the text.
        /// </param>
        public abstract void DrawText(
            ScreenPoint p, 
            string text, 
            OxyColor fill, 
            string fontFamily, 
            double fontSize, 
            double fontWeight, 
            double rotate, 
            HorizontalTextAlign halign, 
            VerticalTextAlign valign, 
            OxySize? maxSize);

        /// <summary>
        /// Measures the text.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="fontFamily">
        /// The font family.
        /// </param>
        /// <param name="fontSize">
        /// Size of the font.
        /// </param>
        /// <param name="fontWeight">
        /// The font weight.
        /// </param>
        /// <returns>
        /// The text size.
        /// </returns>
        public abstract OxySize MeasureText(string text, string fontFamily, double fontSize, double fontWeight);

        /// <summary>
        /// Sets the tool tip for the following items.
        /// </summary>
        /// <param name="text">
        /// The text in the tooltip.
        /// </param>
        /// <params>
        ///   This is only used in the plot controls.
        /// </params>
        public virtual void SetToolTip(string text)
        {
        }

        #endregion
    }
}