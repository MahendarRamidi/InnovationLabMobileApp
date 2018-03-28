using System;
using System.ComponentModel;
using Foundation;
using InnovationLabMobileApp.iOS.Renderers;
using InnovationLabMobileApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AboutFDALabel), typeof(AboutFDALabelRender))]
namespace InnovationLabMobileApp.iOS.Renderers
{
    public class AboutFDALabelRender : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var lineSpacingLabel = (AboutFDALabel)this.Element;
            var paragraphStyle = new NSMutableParagraphStyle()
            {
                LineSpacing = (nfloat)lineSpacingLabel.LineSpacing
            };
            var attrString = new NSMutableAttributedString(lineSpacingLabel.Text);
            var style = UIStringAttributeKey.ParagraphStyle;
            var range = new NSRange(0, attrString.Length);

            attrString.AddAttribute(style, paragraphStyle, range);

            this.Control.AttributedText = attrString;
        }
    }
}
