import Box from '@mui/material/Box';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import { useEffect, useState } from 'react';
import TabLabel from './TabLabel';
import { getColor, FadingTab } from './FadingTab';
import CharacterSheet from '../CharacterSheet/CharacterSheet';
import { useDispatch, useSelector } from 'react-redux';
import { combatState, creationState, locationState } from '../../state/selectors';
import { getOpenedMonster } from '../../state/actions/creationThunk';

// const mockCharacters = [
//   {
//     id: 1,
//     name: "Sixth",
//     initiative: 1,
//     currentHitPoints: 1,
//     hitPoints: 11
//   },
//   {
//     id: 2,
//     name: "Fifth",
//     initiative: 2,
//     currentHitPoints: 1,
//     hitPoints: 10
//   },
//   {
//     id: 3,
//     name: "Fourth",
//     initiative: 4,
//     currentHitPoints: 2,
//     hitPoints: 10
//   },
//   {
//     id: 4,
//     name: "Third",
//     initiative: 6,
//     currentHitPoints: 4,
//     hitPoints: 10
//   },
//   {
//     id: 5,
//     name: "Second",
//     initiative: 8,
//     currentHitPoints: 6,
//     hitPoints: 10
//   },
//   {
//     id: 6,
//     name: "First",
//     initiative: 10,
//     currentHitPoints: 8,
//     hitPoints: 10
//   }
// ]

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
  const { selectedTab: previouslySelected } = useSelector(locationState);
  const { combatants } = useSelector(combatState);

  const getFirst = () => {
    if (previouslySelected !== null) return previouslySelected;
    else return firstInInitiative(combatants);
  }

  const [selectedTab, setSelectedTab] = useState(getFirst());
  const [tabChangeAttempt, setTabChangeAttempt] = useState();
  const dispatch = useDispatch();
  
  useEffect(() => {
    console.log(combatants);
  }, [])

  //
  //
  // const [combatants, setCombatants] = useState([]);
  // const [tabChangeAttempt, setTabChangeAttempt] = useState();
  // const [selectedTab, setSelectedTab] = useState();

  // const creation = useSelector(creationState);
  // const dispatch = useDispatch();

  // useEffect(() => {
  //   dispatch(getOpenedMonster);
  // }, []);

  // useEffect(() => {
  //   if (creation !== null) {
  //     setCombatants([creation.monster]);
  //     setSelectedTab(firstInInitiative([creation.monster]));
  //   }
  // }, [creation])
  //
  //


  const handleInitiativeChange = (id, initiative) => {
    // setCombatants(combatants.map(c => {
    //   if (c.id === id) c.initiative = initiative;
    //   return c;
    // }));
  };

  const handleCloseTab = (id) => {
    // if (selectedTab === id) { // if selected tab is the one, that's being closed
    //   const ids = sorted(combatants).map(c => c.id);
    //   const nextId = ids[ids.indexOf(id) + 1] !== undefined ? ids[ids.indexOf(id) + 1] : ids[ids.indexOf(id) - 1]
    //   setSelectedTab(nextId); // switch to tab to the right of closed tab – or to the left, if there are no tabs to the right
    // }
    // setCombatants(combatants.filter(c => c.id !== id));
  }

  const handleSelectedTabChange = (event, newValue) => { // close button also selects tab,
    // setTabChangeAttempt(newValue); // so each tab select only attempts to change tab
  };
  
  // useEffect(() => { // and useEffect checks, if tabChangeAttempt is a non-closed tab
  //   if (combatants.map(c => c.id).includes(tabChangeAttempt)) {
  //     setSelectedTab(tabChangeAttempt);
  //   }
  // }, [tabChangeAttempt])

  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <TabContext value={selectedTab}>
        <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
          <TabList
            // TabIndicatorProps={{ style: { background: "firebrick" } }}
            variant="scrollable"
            scrollButtons="auto"
            onChange={handleSelectedTabChange}>
              {sorted(combatants).map(combatant =>
                <FadingTab
                  style={getColor(
                    (combatant.currentHitPoints +
                    combatant.temporaryHitPoints) /
                    combatant.hitPoints)} // color depends on creature's HP ratio
                  key={combatant.id}
                  value={combatant.id}
                  label={<TabLabel
                    id={combatant.id}
                    name={combatant.name}
                    init={combatant.initiative}
                    onInitiativeChange={handleInitiativeChange}
                    onClose={handleCloseTab}/>}/>)}
          </TabList>
        </Box>
          {combatants.map(combatant =>
            <TabPanel
              key={combatant.id}
              value={combatant.id}>
                <div className="flex-row">
                  <div className="flex-col">
                    {combatant.name}
                   {/* <CharacterSheet monster={combatant} /> */}
                  </div>
                </div>}
            </TabPanel>)}
      </TabContext>
    </Box>
  );
}

export default CombatTabs;