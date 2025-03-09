using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bravada.Core.Characters
{
    public interface ICharacter
    {
        int LevelMerge { get; set; }
        string CharacterKey { get; set; }
        void MergeCharacters(ICharacter character);
    }
}
