using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class RestorativeEffect : SpellEffect
	{
		private List<AilmentType> _curedAilments = new();
        public List<AilmentType> CuredAilments 
		{ 
			get => _curedAilments; 
			set
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of cured ailments."
					);
				}

				_curedAilments = value;
			}
		}
    }
}
