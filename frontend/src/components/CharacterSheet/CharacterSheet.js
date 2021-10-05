import { Button } from "@mui/material";
import { useDispatch } from "react-redux";
import { getOpenedMonster, saveMonster } from "../../state/actions/creationThunk";
import NumberField from "./NumberField";

const CharacterSheet = ({ monster }) => {
  const dispatch = useDispatch();
  
  const mapped = obj => {
    let array = [];
    let keys = Object.keys(obj);
    let values = Object.values(obj);

    for (let i = 0; i < keys.length; i++) {
      const temp = {
        name : keys[i],
        value : values[i]
      }
      array.push(temp)
    }
    return array;
  }

  const valueOf = (name, monster) => {
    return mapped(monster).find(x => x.name === name).value;
  }

  const handleSave = () => {
    dispatch(saveMonster());
    //
    dispatch(getOpenedMonster());
    //
    if (monster.sourceId == null) {
      dispatch(getOpenedMonster());
    } // update this monster with its sourceId
  }

  return(
    <div>
      <Button onClick={handleSave}>Save</Button>
      <h1>Name: {monster.name}</h1>
      <h1>Source ID: {monster.sourceId}</h1>
      <h1>Initiative: {monster.initiative}</h1>
      <NumberField
        name={"initiative"}
        value={valueOf("initiative", monster)}
      />
    </div>
  );
};

export default CharacterSheet;