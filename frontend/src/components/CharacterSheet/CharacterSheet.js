import { Button } from "@mui/material";
import { useDispatch } from "react-redux";
import { getOpenedMonster, saveMonster } from "../../state/actions/creationThunk";

const CharacterSheet = ({ monster }) => {
  const dispatch = useDispatch();

  const handleSave = () => {
    dispatch(saveMonster());
    if (monster.sourceId == null) {
      dispatch(getOpenedMonster());
    } // update this monster with it's sourceId
  }

  return(
    <div>
      <Button onClick={handleSave}>Save</Button>
      <h1>{monster.name}</h1>
      <h1>{monster.initiative}</h1>
      <h1>{monster.sourceId}</h1>
    </div>
  )
}

export default CharacterSheet;