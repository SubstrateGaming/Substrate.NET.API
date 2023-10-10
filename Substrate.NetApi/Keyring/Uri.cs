using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Substrate.NetApi.Keyring
{
    public class KeyExtractResult
    {
        public string DerivePath { get; set; }
        public string Password { get; set; }
        public IEnumerable<DeriveJunction> Path { get; set; }
        public string Phrase { get; set; }
    }

    public class DeriveJunction
    {
        public byte[] ChainCode { get; set; }

        public static DeriveJunction From(string p)
        {
            throw new NotImplementedException();
        }
    }

    public class Uri
    {
        public const string DEV_PHRASE = "bottom drive obey lake curtain smoke basket hold race lonely fit walk";
        public const string DEV_SEED = "0xfac7959dbfe72f052e5a0c3c8d6530f202b02fd8f9f5ca3580ec8deb7797479e";

        public static Regex CaptureUri = new Regex("/^(\\w+( \\w+)*)((\\/\\/?[^/]+)*)(\\/\\/\\/(.*))?$/");
        public static Regex CaptureJunction = new Regex("/\\/(\\/?)([^/]+)/g");

        public static KeyExtractResult KeyExtractUri(string url)
        {
            var match = CaptureUri.Match(url);

            if(!match.Success) {
                throw new InvalidOperationException("Unable to match provided value to a secret URI");
            }

            var phrase = match.Captures[1].Value;
            var derivePath = match.Captures[3].Value;
            var password = match.Captures[6].Value;

            return new KeyExtractResult()
            {
                DerivePath = derivePath,
                Password = password,
                Path = KeyExtractPath(derivePath).path,
                Phrase = phrase
            };
        }

        public static (string[] parts, DeriveJunction[] path) KeyExtractPath(string derivePath)
        {
            //var parts = CaptureJunction.Match(derivePath);
            //var paths = new List<DeriveJunction>();

            //string construct = string.Empty;

            //if(parts.Success) {
            //    foreach(var p in parts.Groups)
            //    {
            //        paths.Add(DeriveJunction.From(p))
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
