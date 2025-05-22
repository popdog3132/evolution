using System;
using UnityEngine;

public struct ChromosomeStats {

	public string chromosome { get; private set; }
	public CreatureStats stats { get; private set; }

	public ChromosomeStats(string chromosome, CreatureStats stats) {
		this.chromosome = chromosome;
		this.stats = stats;
	}

	public override string ToString ()
	{
		return string.Format("{0}:{1}", chromosome, stats.Encode());
	}

        public static ChromosomeStats FromString(string str) {

                var separatorIndex = str.IndexOf(':');
                if (separatorIndex < 0) {
                        throw new FormatException("Invalid ChromosomeStats string: missing separator");
                }

                var chromosome = str.Substring(0, separatorIndex);
                var statsEncoded = str.Substring(separatorIndex + 1);

                return new ChromosomeStats(chromosome, CreatureStats.Decode(statsEncoded));
        }
}


