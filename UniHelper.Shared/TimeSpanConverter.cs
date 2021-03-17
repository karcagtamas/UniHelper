using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniHelper.Shared
{
    /// <summary>
    /// Time Span Converter
    /// </summary>
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Read TimeSpan from input string.
        /// </summary>
        /// <param name="reader">UTF reader</param>
        /// <param name="typeToConvert">Destination type</param>
        /// <param name="options">Any serialization option</param>
        /// <returns>Read TimeSpan value</returns>
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value ?? string.Empty);
        }

        /// <summary>
        /// Time Span writer.
        /// Write String as value.
        /// </summary>
        /// <param name="writer">UTF writer</param>
        /// <param name="value">TimeSpan value</param>
        /// <param name="options">Any serialization option</param>
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}