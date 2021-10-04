import { useEffect, useState } from "react";

const CharacterSheet = ({ character, add, remove }) => {
  const [selected, setSelected] = useState(false);

  const select = () => {
    add(character);
    setSelected(true);
  }

  const unSelect = () => {
    remove(character);
    setSelected(false);
  }

  const handleChange = () => {
    if (selected) { // previous state
      unSelect();
    } else {
      select();
    }
  }

  useEffect(() => {
    character.hp > 0 && unSelect();
  }, [character.hp])
  
  return (
    <>
      <span>{character.name}</span>
      <input
        disabled={character.hp > 0}
        type="checkbox"
        checked={selected}
        onChange={handleChange} />
    </>
  );
};

export default CharacterSheet;