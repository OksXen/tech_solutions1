import React from 'react';


const DataTable = props => {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            
            <thead>
                <tr>
                    {props.cols.map(col =>
                        <th key={col.name}>{col.header}</th>
                    )}
                </tr>
            </thead>
            
            <tbody>
                {props.data.map(row =>
                    <tr key={row.activityId}>
                        {props.cols.map(col =>
                            <td key={col.name}>{row[col.name]}</td>
                        )}
                    </tr>
                )}
            </tbody>
        </table>
    );
}
export default DataTable;