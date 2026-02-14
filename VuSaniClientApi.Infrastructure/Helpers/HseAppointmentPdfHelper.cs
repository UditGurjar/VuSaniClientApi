using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace VuSaniClientApi.Infrastructure.Helpers
{
    /// <summary>
    /// Data required to generate the HSE Appointment Letter PDF.
    /// </summary>
    public class HseAppointmentPdfData
    {
        public string AppointerFullName { get; set; } = "";
        public string AppointerRoleName { get; set; } = "";
        public string AppointedFullName { get; set; } = "";
        public string AppointmentTypeName { get; set; } = "";
        public string EffectiveDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string OrganizationName { get; set; } = "";
        public string? Designated { get; set; }

        /// <summary>
        /// Organization header image path (relative, stored in DB).
        /// </summary>
        public string? HeaderImage { get; set; }

        /// <summary>
        /// Organization footer image path (relative, stored in DB).
        /// </summary>
        public string? FooterImage { get; set; }

        /// <summary>
        /// Organization business logo path (relative, stored in DB).
        /// </summary>
        public string? BusinessLogo { get; set; }

        /// <summary>
        /// Absolute path to wwwroot folder (e.g. "D:\...\wwwroot").
        /// Used to resolve image file paths.
        /// </summary>
        public string? WebRootPath { get; set; }

        /// <summary>
        /// Organization brand color (hex, e.g. "#6C1D45"). Falls back to "#A6A6A6" if not set.
        /// </summary>
        public string? BrandColor { get; set; }

        /// <summary>
        /// Organization font family/style (e.g. "Tahoma"). Falls back to "Arial" if not set.
        /// </summary>
        public string? FontFamily { get; set; }
    }

    /// <summary>
    /// Generates an HSE Appointment Letter PDF matching the frontend template.
    /// </summary>
    public static class HseAppointmentPdfHelper
    {
        public static byte[] GenerateAppointmentLetterPdf(HseAppointmentPdfData data)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Try to resolve image files from wwwroot/Logo folder
            byte[]? headerBytes = TryLoadImage(data.WebRootPath, data.HeaderImage);
            byte[]? footerBytes = TryLoadImage(data.WebRootPath, data.FooterImage);
            byte[]? logoBytes = TryLoadImage(data.WebRootPath, data.BusinessLogo);

            // Dynamic branding from organization settings
            var brandColor = string.IsNullOrWhiteSpace(data.BrandColor) ? "#A6A6A6" : data.BrandColor;
            var fontFamily = string.IsNullOrWhiteSpace(data.FontFamily) ? "Arial" : data.FontFamily;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(40);
                    page.MarginVertical(0);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily(fontFamily));

                    // Header with image
                    page.Header().Column(hdr =>
                    {
                        if (headerBytes != null)
                        {
                            hdr.Item().Height(60).AlignCenter().Image(headerBytes, ImageScaling.FitArea);
                        }
                        else
                        {
                            hdr.Item().Height(10);
                        }

                        // Logo overlay (centered)
                        if (logoBytes != null)
                        {
                            hdr.Item().PaddingTop(-45).AlignCenter().Height(40).Width(40)
                                .Image(logoBytes, ImageScaling.FitArea);
                        }
                    });

                    page.Content().PaddingHorizontal(0).PaddingTop(10).Column(col =>
                    {
                        // Title
                        col.Item().PaddingBottom(15).AlignCenter().Text("HSE APPOINTMENT LETTER TEMPLATE")
                            .Bold().FontSize(16);

                        // Main table
                        col.Item().Border(1.5f).Column(table =>
                        {
                            // Row 1: Appointer | Appointed
                            table.Item().Row(row =>
                            {
                                row.RelativeItem().Border(0.5f).Padding(8).Column(c =>
                                {
                                    c.Item().Text("Appointer:").Bold().FontSize(11);
                                    c.Item().PaddingTop(4).Row(r =>
                                    {
                                        r.AutoItem().Text("Name:          ").Bold().FontSize(11);
                                        r.RelativeItem().Text(data.AppointerFullName).Underline().FontSize(11);
                                    });
                                    c.Item().PaddingTop(4).Row(r =>
                                    {
                                        r.AutoItem().Text("Role Name:     ").Bold().FontSize(11);
                                        r.RelativeItem().Text(data.AppointerRoleName).Underline().FontSize(11);
                                    });
                                });

                                row.RelativeItem().Border(0.5f).Padding(8).Column(c =>
                                {
                                    c.Item().Text("Appointed:").Bold().FontSize(11);
                                    c.Item().PaddingTop(4).Row(r =>
                                    {
                                        r.AutoItem().Text("Name:          ").Bold().FontSize(11);
                                        r.RelativeItem().Text(data.AppointedFullName).Underline().FontSize(11);
                                    });
                                    c.Item().PaddingTop(4).Row(r =>
                                    {
                                        r.AutoItem().Text("Role Name:     ").Bold().FontSize(11);
                                        r.RelativeItem().Text(data.AppointmentTypeName).Underline().FontSize(11);
                                    });
                                });
                            });

                            // Row 2: Branded banner with appointment type
                            table.Item().Background(brandColor).Padding(10).AlignCenter()
                                .Text(data.AppointmentTypeName).Bold().FontSize(12).FontColor("#FFFFFF");

                            // Row 3: Appointment Validity
                            table.Item().Padding(10).Column(c =>
                            {
                                c.Item().AlignCenter().Text("Appointment Validity").Bold().Underline().FontSize(11);

                                c.Item().PaddingTop(8).Row(r =>
                                {
                                    r.AutoItem().Text("Effective Date:     ").Bold().FontSize(10);
                                    r.AutoItem().Text(data.EffectiveDate).Underline().FontSize(11);
                                    r.AutoItem().PaddingHorizontal(30).Text("End Date:     ").Bold().FontSize(10);
                                    r.AutoItem().Text(string.IsNullOrEmpty(data.EndDate) ? "" : data.EndDate).Underline().FontSize(11);
                                });

                                c.Item().PaddingTop(6).Row(r =>
                                {
                                    r.AutoItem().Text("Business Structure:     ").Bold().FontSize(10);
                                    r.AutoItem().Text(data.OrganizationName).Underline().FontSize(11);
                                });
                            });

                            // Row 4: Legal text and Appointer signature
                            table.Item().Padding(15).Column(c =>
                            {
                                c.Item().Text(text =>
                                {
                                    text.Span("In accordance with section 16 (2) of the Occupational Health and Safety Act, " +
                                        "(85 of 1993), you are hereby charged with ensuring in as far as it is reasonably " +
                                        "practicable that the duties of the employer as contemplated in the OHSAct, are " +
                                        "properly discharged. ").FontSize(10);
                                });

                                c.Item().PaddingTop(20).Row(r =>
                                {
                                    r.AutoItem().Text("___________________").Bold().FontSize(10);
                                    r.AutoItem().PaddingHorizontal(40).Text("_________________________").Bold().FontSize(10);
                                });

                                c.Item().PaddingTop(2).Row(r =>
                                {
                                    r.AutoItem().Text(" Signature").Bold().FontSize(10);
                                    r.AutoItem().PaddingLeft(85).Text("Date ").Bold().FontSize(10);
                                });
                            });

                            // Row 5: Assignments section
                            table.Item().Padding(10).Column(c =>
                            {
                                c.Item().Text("ASSIGNMENTS: ").Bold().FontSize(10);

                                var designatedText = StripHtmlTags(data.Designated);
                                if (!string.IsNullOrWhiteSpace(designatedText))
                                {
                                    c.Item().PaddingTop(6).Text(designatedText).FontSize(10);
                                }
                                else
                                {
                                    c.Item().PaddingTop(6).Text("-").FontSize(10);
                                }

                                c.Item().PaddingTop(10).Text(
                                    "N.B. In delegating these duties I am in no way attempting to forsake my " +
                                    "responsibilities and I acknowledge that the final responsibility lies with me. ")
                                    .Bold().FontSize(10);

                                c.Item().PaddingTop(10).Text(text =>
                                {
                                    text.Span("I,       ").FontSize(10);
                                    text.Span(data.AppointedFullName).Underline().FontSize(10);
                                    text.Span("       hereby accept the above appointment as ").FontSize(10);
                                    text.Span("16(2)").FontSize(10);
                                    text.Span(" and the responsibility / accountability thereof as indicated above. ").FontSize(10);
                                });

                                c.Item().PaddingTop(20).Row(r =>
                                {
                                    r.AutoItem().Text("_________________").Bold().FontSize(10);
                                    r.AutoItem().PaddingHorizontal(40).Text("_________________________").Bold().FontSize(10);
                                });

                                c.Item().PaddingTop(2).Row(r =>
                                {
                                    r.AutoItem().Text("16(2) Signature ").FontSize(10);
                                    r.AutoItem().PaddingLeft(70).Text("Date").FontSize(10);
                                });
                            });

                            // Bottom padding
                            table.Item().PaddingBottom(10).Text("");
                        });
                    });

                    // Footer with image or text
                    page.Footer().Column(ftr =>
                    {
                        if (footerBytes != null)
                        {
                            ftr.Item().Height(40).AlignCenter().Image(footerBytes, ImageScaling.FitArea);
                        }
                        else
                        {
                            ftr.Item().AlignCenter().Text(text =>
                            {
                                text.DefaultTextStyle(x => x.FontSize(8).FontColor("#999999"));
                                text.Span("VuSani Employee Management - HSE Appointment Letter");
                            });
                        }
                    });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }

        /// <summary>
        /// Tries to load an image from wwwroot/Logo/{imagePath}.
        /// Returns null if the file doesn't exist or path is empty.
        /// </summary>
        private static byte[]? TryLoadImage(string? webRootPath, string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(webRootPath) || string.IsNullOrWhiteSpace(imagePath))
                return null;

            try
            {
                // Try direct path under wwwroot first
                var fullPath = Path.Combine(webRootPath, imagePath.TrimStart('/', '\\'));
                if (File.Exists(fullPath))
                    return File.ReadAllBytes(fullPath);

                // Try under wwwroot/Logo subfolder
                var logoPath = Path.Combine(webRootPath, "Logo", imagePath.TrimStart('/', '\\'));
                if (File.Exists(logoPath))
                    return File.ReadAllBytes(logoPath);

                // Try just the filename under wwwroot/Logo
                var fileName = Path.GetFileName(imagePath);
                var fileNamePath = Path.Combine(webRootPath, "Logo", fileName);
                if (File.Exists(fileNamePath))
                    return File.ReadAllBytes(fileNamePath);
            }
            catch
            {
                // Image loading failure should not break PDF generation
            }

            return null;
        }

        /// <summary>
        /// Strips HTML tags from a string for plain text rendering in the PDF.
        /// </summary>
        private static string StripHtmlTags(string? html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return "";

            // Remove HTML tags
            var text = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", " ");
            // Decode common HTML entities
            text = text.Replace("&nbsp;", " ")
                       .Replace("&amp;", "&")
                       .Replace("&lt;", "<")
                       .Replace("&gt;", ">")
                       .Replace("&quot;", "\"")
                       .Replace("&#39;", "'");
            // Collapse multiple spaces
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();
            return text;
        }
    }
}
