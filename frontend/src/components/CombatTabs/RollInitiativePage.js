// import { useDispatch, useSelector } from "react-redux";
// import { getOpenedMonster } from "../../state/selectors/creationSelectors";
// import { NewMonster } from "../../state/actions/creationThunk";
// import { useEffect, useState } from "react";

// const AvailableMonstersAndPlayers = () => {
//   const {characters} = useSelector(getOpenedMonster);
//   const dispatch = useDispatch();
//   const [combatants, setCombatants] = useState([]);

//   const onAdd = (character) => {
//     setCombatants([...combatants, character]);
//   }

//   const onRemove = (character) => {
//     if (combatants.length > 0) {
//       setCombatants(combatants.filter(c => c.id !== character.id));
//     }
//   }

//   return (
//     <div>
//       <button onClick={() => dispatch(NewMonster())}>New character</button>
//       <button onClick={() => dispatch({type: "TEST"})}>Open first character in "Creation"</button>
//       <button onClick={() => console.log(combatants)}>COMBAT</button>
//       <ul>
//         {characters.map(character => <li key={character.id}><CharacterSheet
//           character={character}
//           add={onAdd}
//           remove={onRemove}
//           /></li>)}
//       </ul>
//     </div>
//   );
// };

// const PlayerRow = ({ character, add, remove }) => {
//   const [selected, setSelected] = useState(false);

//   const select = () => {
//     add(character);
//     setSelected(true);
//   }

//   const unSelect = () => {
//     remove(character);
//     setSelected(false);
//   }

//   const handleChange = () => {
//     if (selected) { // previous state
//       unSelect();
//     } else {
//       select();
//     }
//   }

//   useEffect(() => {
//     character.hp > 0 && unSelect();
//   }, [character.hp])
  
//   return (
//     <>
//       <span>{character.name}</span>
//       <input
//         disabled={character.hp > 0}
//         type="checkbox"
//         checked={selected}
//         onChange={handleChange} />
//     </>
//   );
// };