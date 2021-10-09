import { Button, List } from '@mui/material';
import Combatant from './Combatant'
import './Combat.css'
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { monstersState } from '../../state/selectors';

const CombatantList = () => {
  const { monsters } = useSelector(monstersState);
  const [combatRequest, setCombatRequest] = useState([]);

  const handleSelectAmount = (request) => {
    const newCombatRequest = combatRequest.filter(x => x.id !== request.id);
    setCombatRequest([...newCombatRequest, request].filter(x => x.amount > 0));
  }

  // useEffect(() => {
  //   console.log(combatRequest);
  // }, [combatRequest])

  return (
    <>
      <Button
        className="combat-selection-bookends"
        disabled={combatRequest.length === 0}>
        Start Combat
      </Button>
      <div className="combatant-row">
        <List>
          {
          monsters.map(monster => <Combatant
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