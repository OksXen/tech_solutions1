import React from 'react';
import ReactDOM from "react-dom";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";
import { MemoryRouter } from 'react-router-dom';
import FetchEmployeeActivity from '../fetch/FetchEmployeeActivity';
import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import { shallow } from 'enzyme';
import DataTable from '../data-table/DataTable';
import DataTableColumns from '../data-table/dataTableColumns';


configure({ adapter: new Adapter() });


it('renders in table rows based on provided data', async () => {
    const cols = DataTableColumns();

    const fakeEmployeeActivity =
        [
            {
                activityId: "123",
                firstName: "fakefName",
                lastName: "fakelName",
                emailAddress: "fakeemail",
                activityName: "fakeactivityname",
                comments: "fakecomments",
            },
            {
                activityId: "456",
                firstName: "fakefName2",
                lastName: "fakelName2",
                emailAddress: "fakeemail2@adress.com",
                activityName: "fakeactivityname2",
                comments: "fakecomments2",
            }
        ];    
    // Shallow render Data Table
    const container = shallow(<DataTable data={fakeEmployeeActivity} cols={cols} />);


    // There should be ONLY 1 table element
    const table = container.find('table');
    expect(table).toHaveLength(1);
    // The table should have ONLY 1 thead element
    const thead = table.find('thead');
    expect(thead).toHaveLength(1);
    // The number of th tags should be equal to number of columns
    const headers = thead.find('th');
    expect(headers).toHaveLength(cols.length);
    // Each th tag text should equal to column header
    headers.forEach((th, idx) => {
        expect(th.text()).toEqual(cols[idx].header);
    });
    // The table should have ONLY 1 tbody tag
    const tbody = table.find('tbody');
    expect(tbody).toHaveLength(1);
    // There should be ONLY one table row
    const rows = tbody.find('tr');
    expect(rows).toHaveLength(fakeEmployeeActivity.length);


    fakeEmployeeActivity.forEach((employeeActivity => {
        var row = rows.findWhere(row => row.key() === employeeActivity.activityId)        
        expect(row).not.toBe(null)
    }));


});