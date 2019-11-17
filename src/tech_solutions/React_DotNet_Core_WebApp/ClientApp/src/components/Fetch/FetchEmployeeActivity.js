import React, { Component } from 'react';
import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import { shallow } from 'enzyme';
import DataTable from '../data-table/dataTable';
import DataTableColumns from '../data-table/dataTableColumns';

configure({ adapter: new Adapter() });

export class FetchEmployeeActivity extends Component {
    static displayName = FetchEmployeeActivity.name;

    constructor(props) {
        super(props);
        this.state = { employeeActivity: [], loading: true };
    }

    componentDidMount() {
        this.populateEmployeeActivity();
    }

    static renderEmployeeActivityTable(employeeActivities) {

        const cols = DataTableColumns();

        // Shallow render Data Table
        const container = shallow(<DataTable data={employeeActivities} cols={cols} />);
        return (container);
      
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchEmployeeActivity.renderEmployeeActivityTable(this.state.employeeActivity);

        return (
            <div>
                <h1 id="tabelLabel" >Interested Persons Listing</h1>                
                {contents}
            </div>
        );
    }

    async populateEmployeeActivity() {
        const response = await fetch('api/EmployeeActivityApi');
        const data = await response.json();
        this.setState({ employeeActivity: data, loading: false });
    }
}
