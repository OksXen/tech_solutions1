import React from 'react';


const DataTableColumns = props => {
    return (
        [
            { header: 'ID', name: 'activityId' },
            { header: 'First Name', name: 'firstName' },
            { header: 'Last Name', name: 'lastName' },
            { header: 'Email Address', name: 'emailAddress' },
            { header: 'Activity Name', name: 'activityName' },
            { header: 'Comments', name: 'comments' }
        ]
    );
}
export default DataTableColumns;