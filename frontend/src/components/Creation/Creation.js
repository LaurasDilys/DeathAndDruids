import { Button } from "@mui/material";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster, newMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { creationState, monstersState } from "../../state/selectors/creationSelectors";
import CharacterSheet from "../CharacterSheet/CharacterSheet";
import './Creation.css';

const Creation = () => {
  const creation = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getMonsters());
    dispatch(getOpenedMonster());
  }, [])

  const handleNew = () => {
    dispatch(newMonster());
  }

  return (
    <div className="flex-row">
      {creation === null &&
        <div className="flex-col">
          <Button onClick={handleNew}>Create New</Button>
          {monsters.length > 0 &&
          <Button>Load</Button>}
        </div>}
      {creation !== null &&
        <div className="flex-col">
          <CharacterSheet monster={creation.monster} />
        </div>}
    </div>
  );
}

export default Creation;