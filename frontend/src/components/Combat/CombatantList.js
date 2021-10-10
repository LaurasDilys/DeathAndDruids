import { Button, List } from '@mui/material';
import Combatant from './Combatant'
import './Combat.css'
import { useState } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { monstersState } from '../../state/selectors';
import { startCombat } from '../../state/actions/combatThunk';

const CombatantList = () => {
  const { monsters } = useSelector(monstersState);
  const [combatRequest, setCombatRequest] = useState([]);
  const dispatch = useDispatch();

  const handleSelectAmount = (request) => {
    const newCombatRequest = combatRequest.filter(x => x.id !== request.id);
    setCombatRequest([...newCombatRequest, request].filter(x => x.amount > 0));
  }

  const handleStartCombat = () => {
    dispatch(startCombat({
      request: combatRequest
    }));
  }

  return (
    <>
      <Button
        onClick={handleStartCombat}
        className="combat-selection-bookends"
        disabled={combatRequest.length === 0}>
        Start Combat
      </Button>
      <div className="combatant-row">
        <List>
          {[...monsters].sort((a, b) => a.name.localeCompare(b.name))
          .map(monster => <Combatant
            id={monster.id}
            name={monster.name}
            onSelectAmount={handleSelectAmount}
          />)}
        </List>
      </div>
      <div className="combat-selection-bookends">
        <i>Select monsters for combat</i>
      </div>
    </>
  );
};

export default CombatantList;