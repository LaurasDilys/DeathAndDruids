import { Button } from "@mui/material";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { creationState } from "../../state/selectors";
import CharacterSheet from "../CharacterSheet/CharacterSheet";
import './Creation.css';
import Options from "./Options";

const Creation = () => {
  const [canMount, setCanMount] = useState(true);
  const creation = useSelector(creationState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getOpenedMonster());
    dispatch(getMonsters());
  }, [])

  const handleUnmount = () => {
    setCanMount(false);
    window.location.reload();
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
          <Options />
        </div>}
    </div>
  );
}

export default Creation;