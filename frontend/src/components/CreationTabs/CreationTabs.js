import { useDispatch, useSelector } from "react-redux";
import CharacterSheet from "../CharacterSheet/CharacterSheet";
//
import { getCharacters, NewCharacter } from "../../state/actions/actionTypes";
import { useState } from "react";

const CreationTabs = () => {
  const {characters} = useSelector(getCharacters);
  const dispatch = useDispatch();
  const [combatants, setCombatants] = useState([]);

  const onAdd = (character) => {
    setCombatants([...combatants, character]);
  }

  const onRemove = (character) => {
    if (combatants.length > 0) {
      setCombatants(combatants.filter(c => c.id !== character.id));
    }
  }

  return (
    <div>
      <button onClick={() => dispatch(NewCharacter())}>New character</button>
      <button onClick={() => dispatch({type: "TEST"})}>Open first character in "Creation"</button>
      <button onClick={() => console.log(combatants)}>COMBAT</button>
      <ul>
        {characters.map(character => <li key={character.id}><CharacterSheet
          character={character}
          add={onAdd}
          remove={onRemove}
          /></li>)}
      </ul>
    </div>
  );
};

export default CreationTabs;