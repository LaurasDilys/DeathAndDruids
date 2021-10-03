import CombatTabs from './components/CombatTabs/CombatTabs';
import CreationTabs from './components/CreationTabs/CreationTabs';
import HomePage from './components/HomePage/HomePage';

const Routes = [
  {
    title: "Home",
    path: "/",
    getComponent: () => {return HomePage}
  },
  {
    title: "Creation",
    path: "/creation",
    getComponent: () => {return CreationTabs}
  },
  {
    title: "Combat",
    path: "/combat",
    getComponent: () => {return CombatTabs}
  },
  
]

export default Routes;