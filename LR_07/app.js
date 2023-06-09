const { encrypt, decrypt } = require('./util')
const fs = require('fs')
const crypto = require('crypto')

const algorithm = 'aes-192-cbc'
const password = 'Password used to generate key' // secret

const iv = Buffer.alloc(16, 0) // Initialization vector
const key = crypto.scryptSync(password, 'salt', 24)


// console.log(crypto.getCiphers())

const originalText = fs.readFileSync('./original-text.txt')
const encryptedText = encrypt(originalText, algorithm, key, iv)
console.log('Encrypted: ', encryptedText)
const decryptText = decrypt(encryptedText, algorithm, key, iv)
console.log('Decrypted: ', decryptText)

fs.writeFileSync('./encrypted-data.txt', encryptedText)



