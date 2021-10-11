import Box from '@mui/material/Box';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import { useEffect, useState } from 'react';
import TabLabel from './TabLabel';
import { getColor, FadingTab } from './FadingTab';
import { useDispatch, useSelector } from 'react-redux';
import { combatState } from '../../state/selectors';
import CombatSheet from '../CharacterSheet/CombatSheet';
import { deleteCombatant, patchCombatant } from '../../state/actions/combatThunk';

const getHpRatio = (combatant) => {
  return (combatant.currentHitPoints + combatant.temporaryHitPoints) / combatant.hitPoints;
}

const sorted = (combatants) => {
  return [...combatants].sort((a, b) => {
    return b.initiative - a.initiative;
  });
}

const firstInInitiative = (combatants) => {
  const list = sorted(combatants);
  return list.length === 0 ? 0 : list[0].id;
}

const CombatTabs = () => {
  const { combatants } = useSelector(combatState);
  const [selectedTab, setSelectedTab] = useState(firstInInitiative(combatants));
  const [tabChangeAttempt, setTabChangeAttempt] = useState(0);
  const [lastClosed, setLastClosed] = useState(0);
  const dispatch = useDispatch();

  const handleInitiativeChange = (id, initiative) => {
    dispatch(patchCombatant({
      id: id,
      name: "initiative",
      value: initiative
    }));
  };

  const handleCloseTab = (id) => {
    if (selectedTab === id) { // if selected tab is the one, that's being closed
      const ids = sorted(combatants).map(c => c.id);
      const nextId = ids[ids.indexOf(id) + 1] !== undefined ? ids[ids.indexOf(id) + 1] : ids[ids.indexOf(id) - 1]
      setSelectedTab(nextId); // switch to tab to the right of closed tab – or to the left, if there are no tabs to the right
    }
    setLastClosed(id);
    dispatch(deleteCombatant(id));
  }

  const handleSelectedTabChange = (event, newValue) => { // close button also selects tab,
    setTabChangeAttempt(newValue); // so each tab select only attempts to change tab
  };
  
  useEffect(() => { // and useEffect checks, if tabChangeAttempt is a non-closed tab
    if (tabChangeAttempt !== lastClosed) {
      setSelectedTab(tabChangeAttempt);
    }
  }, [tabChangeAttempt])

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={selectedTab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList
            variant="scrollable"
            scrollButtons="auto"
            onChange={handleSelectedTabChange}>
            {sorted(combatants).map(combatant =>
            <FadingTab
              style={getColor(getHpRatio(combatant))}
              key={combatant.id}
              value={combatant.id}
              label={<TabLabel
                id={combatant.id}
                name={combatant.name}
                init={combatant.initiative}
                onInitiativeChange={handleInitiativeChange}
                onClose={handleCloseTab}
              />}
            />)}
          </TabList>
        </Box>
          {combatants.map(combatant =>
          <TabPanel
            key={combatant.id}
            value={combatant.id}>
            <div className="flex-row-80">
              <div className="flex-col">
                <CombatSheet monster={combatant} />
              </div>
            </div>
          </TabPanel>)}
      </TabContext>
    </Box>
  );
}

export default CombatTabs;