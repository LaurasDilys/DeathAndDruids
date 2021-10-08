import { Button } from "@mui/material";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster, newMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { creationState, monstersState } from "../../state/selectors/creationSelectors";
import CharacterSheet from "../CharacterSheet/CharacterSheet";
import './Creation.css';
import Options from "./Options";

const Creation = () => {
  const [canMount, setCanMount] = useState(true);
  const creation = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getOpenedMonster());
    dispatch(getMonsters());
  }, [])

  const handleUnmount = () => {
    setCanMount(false);
  }

  useEffect(() => {
    creation !== null && setCanMount(true);
  }, [creation])

  return (
    <div className="flex-row">
      {canMount && creation !== null &&
        <div className="flex-col">
          <CharacterSheet unmountMe={handleUnmount} monster={creation.monster} />
        </div>}
      {(!canMount || creation === null) &&
        <div className="flex-col">
          <Button onClick={() => console.log(creation)} >CREATION</Button>
          <Options />
        </div>}
    </div>
  );
}

export default Creation;