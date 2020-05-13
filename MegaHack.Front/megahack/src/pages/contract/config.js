export const TODO_LIST_ADDRESS = '0xC7313598B4b10D9ec23c934953356bCb23880fD5'

export const TODO_LIST_ABI = [
	{
		"constant": false,
		"inputs": [
			{
				"name": "_info",
				"type": "string"
			}
		],
		"name": "setInfo",
		"outputs": [],
		"payable": false,
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
		"constant": true,
		"inputs": [],
		"name": "getInfo",
		"outputs": [
			{
				"name": "",
				"type": "string"
			}
		],
		"payable": false,
		"stateMutability": "view",
		"type": "function"
	}
]