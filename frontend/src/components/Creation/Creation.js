import { Button } from "@mui/material";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { creationState, monstersState } from "../../state/selectors/creationSelectors";
import './Creation.css';

const Creation = () => {
  const creation = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getOpenedMonster())
    dispatch(getMonsters());
  }, [])

  return (
    <div className="flex-row">
      {creation === null &&
        <div className="flex-col">
          <Button>Create New</Button>
          {monsters.length > 0 &&
          <Button>Load</Button>}
        </div>}
    </div>
  );
}

export default Creation;