import { Button } from "@mui/material";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { getOpenedMonster, saveMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import NameField from "./NameField";
import NumberField from "./NumberField";

const CharacterSheet = ({ monster }) => {
  const [cannotBeSaved, setCannotBeSaved] = useState([]);
  const dispatch = useDispatch();
  
  const mapped = obj => {
    let array = [];
    let keys = Object.keys(obj);
    let values = Object.values(obj);

    for (let i = 0; i < keys.length; i++) {
      const monsterPropertyAsNameAndValue = {
        name : keys[i],
        value : values[i]
      }
      array.push(monsterPropertyAsNameAndValue)
    }
    return array;
  }

  const valueOf = name => {
    return mapped(monster).find(x => x.name === name).value;
  }

  const handleSave = () => {
    dispatch(saveMonster());
    if (monster.sourceId === null) {
      dispatch(getOpenedMonster());
    } // update this monster with its sourceId
    // ISSUE: dispatch(getOpenedMonster()) takes too long to resolve
  // Therefore, sourceId doesn't get updated quickly enough
    dispatch(getMonsters());
  }

  const handleSaveButtonValidation = (field, bool) => {
    if (bool === true) setCannotBeSaved([...cannotBeSaved, field]);
    else setCannotBeSaved(cannotBeSaved.filter(x => x !== field));
    console.log(`${field} cannot be saved: ${bool}`);
  }

  return(
    <div>
      <Button disabled={cannotBeSaved.length > 0} onClick={handleSave}>Save</Button>
      <h1>SourceId: {monster.sourceId !== null ? monster.sourceId : 0}</h1>
      <h2>Name: {monster.name}</h2>
      <NameField
        sourceId={monster.sourceId}
        name={"name"}
        value={valueOf("name")}
        cannotBeSaved={handleSaveButtonValidation}
      />
      <h2>Initiative: {monster.initiative}</h2>
      <NumberField
        name={"initiative"}
        value={valueOf("initiative")}
        cannotBeSaved={handleSaveButtonValidation}
      />
    </div>
  );
};

export default CharacterSheet;