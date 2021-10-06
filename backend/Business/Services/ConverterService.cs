using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ConverterService
    {
        public void TransformIntoFullCharacter(Character character, CharacterDataModel characterDb)
        {
            character.Name = characterDb.Name;
            character.Initiative = characterDb.Initiative;
        }

        public void TransformIntoDataModel(CharacterDataModel characterDb, Character character)
        {
            characterDb.Name = character.Name;
            characterDb.Initiative = character.Initiative;
        }
    }
}
