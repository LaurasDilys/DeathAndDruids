import './App.css';
import { BrowserRouter as Router, Switch, Route, useLocation } from 'react-router-dom';
import Routes from './Routes';
import SideNav from './components/SideNav/SideNav';

const LocationTracker = (props) => {
  const location = useLocation();
  console.log(location);

  return props.children;
}

const App = () => {
  return (
    <Router>
      <LocationTracker>
        <SideNav routes={Routes} />
        <Switch>
          {Routes.map(({ path, getComponent }, index) => <Route
            key={index}
            exact={path === "/"}
            path={path}
            component={getComponent()} />)}
        </Switch>
      </LocationTracker>
    </Router>
  );
}

export default App;
