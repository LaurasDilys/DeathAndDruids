import './App.css';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Routes from './Routes';
import SideNav from './components/SideNav/SideNav';

const App = () => {
  return (
    <Router>
      <SideNav routes={Routes} />
      <Switch>
        {Routes.map(({ path, getComponent }, index) => <Route
          key={index}
          path={path}
          component={getComponent()} />)}
      </Switch>
    </Router>
  );
}

export default App;
