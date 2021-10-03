import { useDispatch, useSelector } from "react-redux";
import CharacterSheet from "../CharacterSheet/CharacterSheet";
//
import { getCharacters, NewCharacter } from "../../state/actions/actionTypes";

const CreationTabs = () => {
  const {characters} = useSelector(getCharacters);
  const dispatch = useDispatch();

  return (
    <div>
      <button onClick={() => dispatch(NewCharacter())}>New Character</button>
      <ul>
        {characters.map(character => <li><CharacterSheet character={character} /></li>)}
      </ul>
    </div>
  );
};

export default CreationTabs;