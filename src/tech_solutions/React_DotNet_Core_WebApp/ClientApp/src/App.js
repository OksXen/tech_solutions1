import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchEmployeeActivity } from './components/Fetch/FetchEmployeeActivity';
import { FetchEmployeeActivityByDapper } from './components/Fetch/FetchEmployeeActivityByDapper';
import { AddEmployeeActivityByDapper } from './components/CRUD/AddEmployeeActivityByDapper';
import { AddEmployeeActivity } from './components/CRUD/AddEmployeeActivity';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />        
            <Route path='/fetch-employee-activity' component={FetchEmployeeActivity} />
            <Route path='/fetch-employee-activity-by-dapper' component={FetchEmployeeActivityByDapper} />
            <Route path='/add-employee-activity' component={AddEmployeeActivity} />
            <Route path='/add-employee-activity-by-dapper' component={AddEmployeeActivityByDapper} />
            
      </Layout>
    );
  }
}
